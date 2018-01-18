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
    /// <summary>
    /// Products Controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        private ApiContext _apiContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiContext"></param>
        public ProductsController(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        // GET: api/Products
        //[Authorize]
        /// <summary>
        /// Get Products List
        /// </summary>
        /// <param name="page"></param>
        /// <param name="results"></param>
        /// <param name="sortField"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        /// <response code="200">Returns products by pagination.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PageBase<List<ProductDTO>>), 200)]
        public async Task<IActionResult> GetProducts(int page = 1, int results = 10, string sortField = "", string sortOrder = "")
        {
            var products = from b in _apiContext.Products.Skip((page - 1) * results).Take(10)
                           select new ProductDTO()
                           {
                               Id = b.Id,
                               Name = b.Name,
                               Price = b.Price,
                               TypeProductId = b.TypeProductId,
                               TypeProductName = b.TypeProduct.Name,
                               Description = b.Description
                           };

            var page1 = new PageBase<List<ProductDTO>>
            {
                Results = products.ToList()
            };
            page1.Info = new PageBase<List<ProductDTO>>.Information
            {
                Page = 1,
                Results = 6,
                Seed = "fdsfsfdsfds",
                Version = "1.1",
                Total = _apiContext.Products.Count()
            };

            return Ok(page1);
        }

        /// <summary>
        /// Get Product by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductoDetailDTO), 200)]
        [ProducesResponseType(typeof(ProductoDetailDTO), 404)]
        public async Task<IActionResult> GetProduct(int id)
        {
            if (!ProductExists(id))
            {
                return NotFound(id);
            }

            var product = await _apiContext.Products.Include(b => b.TypeProduct).Select(b =>
            new ProductoDetailDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                Price = b.Price,
                TypeProductName = b.TypeProduct.Name,
                TypeProductId = b.TypeProduct.Id
            }).SingleOrDefaultAsync(b => b.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        // PUT: api/Products/5
        //[Authorize]
        //[ResponseType(typeof(void))]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Product), 400)]
        [ProducesResponseType(typeof(Product), 404)]
        public IActionResult PutProduct(int id, [FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            if (!ProductExists(id))
            {
                return NotFound(id);
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

            return new NoContentResult();
        }

        /// <summary>
        /// Add new Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        // POST: api/Products
        //[Authorize]
        //[ResponseType(typeof(Product))]
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody]Product product)
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

            return CreatedAtRoute("GetProduct", new { id = product.Id }, dto);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(Product), 200)]
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