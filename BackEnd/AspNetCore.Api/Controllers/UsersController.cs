using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Api.Controllers
{
    /// <summary>
    /// Users Controller(Inmemory)
    /// </summary>
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly ApiContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiContext"></param>
        public UsersController(ApiContext apiContext)
        {
            this._context = apiContext;
        }

        /// <summary>
        /// Get Users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users
                .Include(u => u.Posts)
                .ToArrayAsync();

            var response = users.Select(u => new
            {
                firstName = u.FirstName,
                lastName = u.LastName,
                posts = u.Posts.Select(p => p.Content)
            });

            return Ok(response);
        }
    }
}