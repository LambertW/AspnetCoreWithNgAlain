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
    [Route("api/TypeProducts")]
    public class TypeProductsController : Controller
    {
        private ApiContext _context;

        public TypeProductsController(ApiContext apiContext)
        {
            _context = apiContext;
        }

        /// <summary>
        /// Get TypeProducts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(TypeProduct), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var list = await _context.TypeProducts.ToListAsync();
            return Ok(list);
        }
    }
}