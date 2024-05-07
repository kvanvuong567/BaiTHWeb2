using BTH_BUOI1.Data;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models.Sorted;
using BTH_BUOI1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BTH_BUOI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IAuthorRepository _authorrepository;

        public AuthorController (AppDbContext dbContext, IAuthorRepository authorrepository)
        {
            _dbContext = dbContext;
            _authorrepository = authorrepository;
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAll(SortField sorted, 
            string? authorName = null,
            int page = 1, int pageSize = 10)
        {
            var allAuthors = _authorrepository.GetAllAuthors(sorted);

            if (!string.IsNullOrEmpty(authorName))
            {
                allAuthors = allAuthors.Where(a => a.FullName.Contains(authorName)).ToList();
            }
            // Phân trang
            var totalItems = allAuthors.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var booksOnPage = allAuthors.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var paginationMetadata = new
            {
                totalItems,
                pageSize,
                currentPage = page,
                totalPages
            };

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

            return Ok(booksOnPage);
        }

        [HttpGet]
        [Route("get-author-by-id/{id}")]
        public IActionResult GetAuthorById([FromRoute] int id)
        {
            var authorWithIdDTO = _authorrepository.GetAuthorById(id);
            return Ok(authorWithIdDTO);
        }
        [HttpPost("add - author")]
        public IActionResult AddAuthor([FromBody] AddAuthorRequestDTO addAuthorRequestDTO)
        {
            var authorAdd = _authorrepository.AddAuthor(addAuthorRequestDTO);
            return Ok(authorAdd);
        }
        [HttpPut("update-author-by-id/{id}")]
        public IActionResult UpdateAuthorById(int id, [FromBody] AddAuthorRequestDTO authorDTO)
        {
            var updateAuthor = _authorrepository.UpdateAuthorById(id, authorDTO);
            return Ok(updateAuthor);
        }
        [HttpDelete("delete-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            var deleteAuthor = _authorrepository.DeleteAuthorById(id);
            return Ok(deleteAuthor);
        }
    }
}
