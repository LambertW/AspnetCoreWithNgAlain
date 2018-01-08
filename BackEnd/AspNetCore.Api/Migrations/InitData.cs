using AspNetCore.Api.Models;
using AspNetCore.Api.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Migrations
{
    /// <summary>
    /// Init Data
    /// </summary>
    public class InitData
    {
        /// <summary>
        /// Seed.
        /// </summary>
        /// <param name="context"></param>
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

        public static void AddProductsData(ApiContext context)
        {
            context.TypeProducts.Add(new TypeProduct() { Id = 1, Name = "Hardware" });
            context.TypeProducts.Add(new TypeProduct() { Id = 2, Name = "Juguetes" });
            context.TypeProducts.Add(new TypeProduct() { Id = 3, Name = "Software" });

            context.Products.Add(new Product()
            {
                Id = 1,
                Name = "Producto 1",
                Description = "Un producto comun",
                TypeProductId = 1,
                Price = 9.99M
            });
            context.Products.Add(new Product()
            {
                Id = 2,
                Name = "Producto 4",
                Description = "Un producto comun",
                TypeProductId = 2,
                Price = 9.99M
            });
            context.Products.Add(new Product()
            {
                Id = 3,
                Name = "Producto 2",
                Description = "Un producto comun",
                TypeProductId = 3,
                Price = 9.99M
            });
            context.Products.Add(new Product()
            {
                Id = 4,
                Name = "Producto 3",
                Description = "Un producto comun",
                TypeProductId = 1,
                Price = 9.99M
            });

            context.SaveChanges();
        }
    }
}
