using BTH_BUOI1.Data;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models.Sorted;
using BTH_BUOI1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;

namespace BTH_BUOI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IPublisherRepository _publisherRepository;

        public PublisherController (AppDbContext dbContext, IPublisherRepository publisherRepository)
        {
            _dbContext = dbContext;
            _publisherRepository = publisherRepository;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(SortField sorted, 
            string? publisherName = null,
            int page = 1, int pageSize = 10
            )
        {
            var allPublishers = _publisherRepository.GetAllPublishers(sorted);
            
            if (!string.IsNullOrEmpty(publisherName))
            {
                allPublishers = allPublishers.Where(p => p.Name.Contains(publisherName)).ToList();
            }
            // Phân trang
            var totalItems = allPublishers.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var booksOnPage = allPublishers.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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
        [Route("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById([FromRoute] int id)
        {
            var publisherWithIdDTO = _publisherRepository.GetPublishersById(id);
            return Ok(publisherWithIdDTO);
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] AddPublisherRequestDTO addPublisherRequestDTO)
        {
            var publisherAdd = _publisherRepository.AddPublishers(addPublisherRequestDTO);
            return Ok(publisherAdd);
        }

        [HttpPut("update-publisher-by-id/{id}")]
        public IActionResult UpdatePublisherById(int id, [FromBody] AddPublisherRequestDTO publisherDTO)
        {
            var updatePublisher = _publisherRepository.UpdatePublisherById(id, publisherDTO);
            return Ok(updatePublisher);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            var deletePublisher = _publisherRepository.DeletePublisherById(id);
            return Ok(deletePublisher);
        }

    }
}
