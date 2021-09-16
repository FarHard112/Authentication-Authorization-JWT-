using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthResource.API.Models
{
    public class BookStore
    {
        public List<Book> Books => new List<Book>()
        {
            new Book() {Id = 1, Author = "FakeAuthor1", Title = "FakeBook1", Price = 15M},
            new Book() {Id = 2, Author = "FakeAuthor2", Title = "FakeBook2", Price = 25M},
            new Book() {Id = 3, Author = "FakeAuthor3", Title = "FakeBook3", Price = 45M},
            new Book() {Id = 4, Author = "FakeAuthor4", Title = "FakeBook4", Price = 65M},
        };

        public Dictionary<Guid, int[]> Orders => new Dictionary<Guid, int[]>()
        {
            {Guid.Parse("4b6a6b9a-2303-402a-9970-6e71f4a47151"), new[] {1, 3}},
            {Guid.Parse("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"), new[] {1, 2, 4}},
        };

    }
}
