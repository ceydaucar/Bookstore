using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;
using static WebApi.BookOperations.DeleteBook.DeleteBookCommand;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        // endpoint yazıyoruz
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        // yeni endpoint yazıyoruz
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;

                GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
                validator.ValidateAndThrow(query);

                result = query.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
            
            return Ok(result);
        }

        // Post
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook) // normalde postta bir şey dönmek gerekmez ama başarılı/başarısız ayrımının geri dönmesi için IActionResult yazılır.
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            try
            {
                command.Model = newBook;

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();

                // if (!result.IsValid)
                //     foreach (var item in result.Errors)
                //         Console.WriteLine("Property: " + item.PropertyName + "- Error Message: " + item.ErrorMessage);
                // else
                //     
                
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // Put
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook) // normalde postta bir şey dönmek gerekmez ama başarılı/başarısız ayrımının geri dönmesi için IActionResult yazılır.
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);

                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;

                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                
                command.Handle();
            }
            catch (Exception ex)
            {
                
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }   
}