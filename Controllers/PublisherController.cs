using BTH_BUOI1.Data;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _publisherRepository.GetAllPublishers();
            return Ok(allPublishers);
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
