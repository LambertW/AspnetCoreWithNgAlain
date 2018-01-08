using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Api.Models.Products
{
    public class ProductoDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string TypeProductName { get; set; }
        public string Description { get; set; }
    }
}
