using AuthResource.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace AuthResource.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BookStore _bookStore;

        private Guid UserId => Guid.Parse(User.Claims.Single(x
            => x.Type == ClaimTypes.NameIdentifier).Value);

        public OrderController(BookStore bookStore)
        {
            _bookStore = bookStore;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("")]
        public IActionResult GetOrders()
        {
            if (!_bookStore.Orders.ContainsKey(UserId)) return Ok(Enumerable.Empty<Book>());
            var orderBooksIds = _bookStore.Orders.Single(x => x.Key == UserId).Value;
            var orderedBooks = _bookStore.Books.Where(c => orderBooksIds.Contains(c.Id));
            return Ok(orderedBooks);
        }
    }
}