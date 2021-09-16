using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthResource.API.Models;

namespace AuthResource.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookStore _bookStore;

        public BooksController(BookStore bookStore)
        {
            _bookStore = bookStore;
        }
        [HttpGet]
        [Route("getbooks")]
        public IActionResult GetAvaibleBooks()
        {
            return Ok(_bookStore.Books);
        }
    }
}
