﻿using BTH_BUOI1.CustomActionFilter;
using BTH_BUOI1.Data;
using BTH_BUOI1.Models.DTO;
using BTH_BUOI1.Models.Sorted;
using BTH_BUOI1.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace WebAPI_simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BooksController> _logger;
        public BooksController(AppDbContext dbContext, IBookRepository bookRepository, 
            ILogger<BooksController> logger)
        {
            _dbContext = dbContext;
            _bookRepository = bookRepository;
            _logger = logger;
        }
       
        [HttpGet("get-all-books")]
        [Authorize(Roles = "Read,Write")]
        public IActionResult GetAll(SortField sorted,
            string? bookTitle = null, 
            string? publisherName = null, 
            int page = 1, int pageSize = 10)
        {
            _logger.LogInformation("GetAll Book Action method was invoked");
            _logger.LogWarning("This is a warning log");
            _logger.LogError("This is a error log");
            // su dung reposity pattern
            var allBooks = _bookRepository.GetAllBooks(sorted);
            //debug
            _logger.LogInformation("Finished GetAllBook request with data: {Data}", JsonSerializer.Serialize(allBooks));
            //tim kiem
            if (!string.IsNullOrEmpty(bookTitle))
            {
                allBooks = allBooks.Where(b => b.Title.Contains(bookTitle)).ToList();
            }
            if (!string.IsNullOrEmpty(publisherName))
            {
                allBooks = allBooks.Where(b => b.PublisherName != null && b.PublisherName.Contains(publisherName)).ToList();
            }

            // Phân trang
            var totalItems = allBooks.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var booksOnPage = allBooks.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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
        [Route("get-book-by-id/{id}")]
        [Authorize(Roles = "Read,Write")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            var bookWithIdDTO = _bookRepository.GetBookById(id);
            return Ok(bookWithIdDTO);
        }
        
        [HttpPost("add - book")]
        [Authorize(Roles ="Write")]
        [ValidateModel]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {
            //validate request
            if (!ValidateAddBook(addBookRequestDTO))
            {
                return BadRequest(ModelState);
            }
            // before add data 
            if (ModelState.IsValid)
            {
                var bookAdd = _bookRepository.AddBook(addBookRequestDTO);
                return Ok(bookAdd);
            }
            else return BadRequest(ModelState);

        }
        [HttpPut("update-book-by-id/{id}")]
        [Authorize(Roles = "Write")]
        public IActionResult UpdateBookById(int id, [FromBody] AddBookRequestDTO bookDTO)
        {
            var updateBook = _bookRepository.UpdateBookById(id, bookDTO);
            return Ok(updateBook);
        }
        [HttpDelete("delete-book-by-id/{id}")]
        [Authorize(Roles = "Write")]
        public IActionResult DeleteBookById(int id)
        {
            var deleteBook = _bookRepository.DeleteBookById(id);
            return Ok(deleteBook);
        }

        #region Private methods
        private bool ValidateAddBook(AddBookRequestDTO addBookRequestDTO)
        {
            if (addBookRequestDTO == null)
            {
                ModelState.AddModelError(nameof(addBookRequestDTO), $"Please add book data");
            return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(addBookRequestDTO.Description))
            {
                ModelState.AddModelError(nameof(addBookRequestDTO.Description),
               $"{nameof(addBookRequestDTO.Description)} cannot be null");
            }
            // kiem tra rating (0,5)
            if (addBookRequestDTO.Rate < 0 || addBookRequestDTO.Rate > 5)
            {
                ModelState.AddModelError(nameof(addBookRequestDTO.Rate),
               $"{nameof(addBookRequestDTO.Rate)} cannot be less than 0 and more than 5");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
