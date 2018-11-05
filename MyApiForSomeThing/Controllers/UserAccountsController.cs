using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApiForSomeThing.Data;
using MyApiForSomeThing.Models;

namespace MyApiForSomeThing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public UserAccountsController(MyApiContext context)
        {
            _context = context;
        }

        // GET: api/UserAccounts
        [HttpGet]
        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            return _context.UserAccounts;
        }

        // GET: api/UserAccounts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUserAccount([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            return Ok(userAccount);
        }

        // PUT: api/UserAccounts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAccount([FromRoute] long id, [FromBody] UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userAccount.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAccount).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!UserAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserAccounts
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateUserAccount([FromBody] UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserAccounts.Add(userAccount);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetOneUserAccount", new {id = userAccount.Id}, userAccount);
        }

        // DELETE: api/UserAccounts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAccount([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAccount = await _context.UserAccounts.FindAsync(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _context.UserAccounts.Remove(userAccount);
            await _context.SaveChangesAsync();
            return Ok(userAccount);
        }

        public bool UserAccountExists(long id)
        {
            return _context.UserAccounts.Any(user => user.Id == id);
        }
    }
}