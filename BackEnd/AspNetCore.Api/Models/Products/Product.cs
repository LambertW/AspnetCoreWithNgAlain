using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Models.Products
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        // Foreign Key
        public int TypeProductId { get; set; }

        // Navigation property
        public TypeProduct TypeProduct { get; set; }
    }
}
