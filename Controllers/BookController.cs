using BTH_BUOI1.Data;
using BTH_BUOI1.Models.Domain;
using BTH_BUOI1.Models.DTO;
using Microsoft.AspNetCore.Mvc;
namespace BTH_BUOI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public BookController(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAll()
        {
            var allBooksDomain = _dbContext.Books;

            var allBooksDTO = allBooksDomain.Select(Books => new BookWithAuthorAndPublisherDTO()
            {
                ID = Books.ID,
                Title = Books.Title,
                Description = Books.Description,
                IsRead = Books.IsRead,
                DateRead = Books.DateRead ?? null,
                Rate = Books.Rate ?? null,
                Genre = Books.Genre,
                CoverUrl = Books.CoverUrl,
                PublisherName = Books.Publisher.Name,
                AuthorName = Books.Book_Authors.Select(n => n.Author.FullName).ToList(),
            }).ToList();
            return Ok(allBooksDTO);
        }
        [HttpGet]
        [Route("get-all-books/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _dbContext.Books.Where(n => n.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            var allBooksDTO = book.Select(b => new BookWithAuthorAndPublisherDTO()
            {
                ID = b.ID,
                Title = b.Title,
                Description = b.Description,
                IsRead = b.IsRead,
                DateRead = b.DateRead ?? null,
                Rate = b.Rate ?? null,
                Genre = b.Genre,
                CoverUrl = b.CoverUrl,
                PublisherName = b.Publisher.Name,
                AuthorName = b.Book_Authors.Select(n => n.Author.FullName).ToList(),
            }).ToList();
            return Ok(allBooksDTO);
        }
        //[HttpGet]
        //[Route("get-all-books/{id}")]
        //public IActionResult GetBook(int id)
        //{
        //    var book = _dbContext.Books.Find(id);

        //    if (book == null)
        //    {
        //        return StatusCode(StatusCodes.Status204NoContent, "No books in database.");
        //    }
        //    return StatusCode(StatusCodes.Status200OK, book);
        //}
    }
}
