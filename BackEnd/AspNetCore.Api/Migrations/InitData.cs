using AspNetCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Migrations
{
    public class InitData
    {
        public static void AddTestData(ApiContext context)
        {
            var testUser1 = new User
            {
                Id = "abc123",
                FirstName = "Luke",
                LastName = "Skywar"
            };

            context.Users.Add(testUser1);

            var testPost1 = new Post
            {
                Id = "def234",
                UserId = testUser1.Id,
                Content = "Post Content 111"
            };

            context.Posts.Add(testPost1);

            context.SaveChanges();
        }
    }
}
