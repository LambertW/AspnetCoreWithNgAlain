using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AspNetCore.Api.Models;
using AspNetCore.Api.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private ApiContext _apiContext;

        public ProductsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        // GET: api/Products
        //[Authorize]
        [HttpGet]
        public PageBase<List<ProductDTO>> GetProducts()
        {
            var products = from b in _apiContext.Products
                           select new ProductDTO()
                           {
                               Id = b.Id,
                               Name = b.Name,
                               Price = b.Price,
                               TypeProductId = b.TypeProductId,
                               TypeProductName = b.TypeProduct.Name,
                               Description = b.Description
                           };

            var page = new PageBase<List<ProductDTO>>
            {
                results = products.ToList()
            };
            page.info = new PageBase<List<ProductDTO>>.Info
            {
                page = 1,
                results = 6,
                seed = "fdsfsfdsfds",
                version = "1.1"
            };

            return page;
        }

        // TODO: German :)
        // we're converting to DTOs manually in code. Another option is to use a library like AutoMapper that handles the conversion automatically.
        // since the program is simple, it was chosen to use the quick way

        // GET: api/Products/5
        //[Authorize]
        //[ResponseType(typeof(ProductoDetailDTO))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _apiContext.Products.Include(b => b.TypeProduct).Select(b =>
            new ProductoDetailDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Price = b.Price,
                TypeProductName = b.TypeProduct.Name
            }).SingleOrDefaultAsync(b => b.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        //[Authorize]
        //[ResponseType(typeof(void))]
        [HttpPut]
        public IActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _apiContext.Entry(product).State = EntityState.Modified;

            try
            {
                _apiContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        // POST: api/Products
        //[Authorize]
        //[ResponseType(typeof(Product))]
        [HttpPost]
        public async Task<IActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _apiContext.Products.Add(product);
            await _apiContext.SaveChangesAsync();

            _apiContext.Entry(product).Reference(x => x.TypeProduct).Load();

            var dto = new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                TypeProductId = product.TypeProductId,
                TypeProductName = product.TypeProduct.Name,
                Description = product.Description
            };

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, dto);
        }

        // DELETE: api/Products/5
        //[Authorize]
        //[ResponseType(typeof(Product))]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            Product product = _apiContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            _apiContext.Products.Remove(product);
            _apiContext.SaveChanges();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _apiContext.Products.Count(e => e.Id == id) > 0;
        }
    }
}