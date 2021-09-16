using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthJWT.Models;

namespace AuthJWT
{
    public  class MockDatabase
    {
        public  List<Account> Accounts => new List<Account>()
        {
            new Account()
            {
                Id = Guid.Parse("4b6a6b9a-2303-402a-9970-6e71f4a47151"),
                Email = "test@email.com",
                Password = "user",
                Roles = new Role[] {Role.User}
            },
            new Account()
            {
                Id = Guid.Parse("c72e5cb5-d6b4-4c0c-9992-d7ae1c53a820"),
                Email = "test1@email.com",
                Password = "user1",
                Roles = new Role[] {Role.User}
            },
            new Account()
            {
                Id = Guid.Parse("7de3299b-2796-4982-a85b-2d6d1326396e"),
                Email = "test2@email.com",
                Password = "user",
                Roles = new Role[] {Role.Admin}
            }
        };
    }
}
