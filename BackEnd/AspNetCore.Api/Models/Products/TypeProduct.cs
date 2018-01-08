using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Api.Models.Products
{
    public class TypeProduct
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}