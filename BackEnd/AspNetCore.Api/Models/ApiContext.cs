using AspNetCore.Api.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Models
{
    /// <summary>
    /// Db Context
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {

        }

        /// <summary>
        /// Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Posts
        /// </summary>
        public DbSet<Post> Posts { get; set; }


        public DbSet<Products.Product> Products { get; set; }

        public DbSet<TypeProduct> TypeProducts { get; set; }
    }
}
