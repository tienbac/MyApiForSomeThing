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
    public class UserInformationsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public UserInformationsController(MyApiContext context)
        {
            _context = context;
        }

        // GET: api/UserInformations
        [HttpGet]
        public IEnumerable<UserInformation> GetUserInformations()
        {
            return _context.UserInformations;
        }

        // GET: api/UserInformations/{email}
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserInformation([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInformation = await _context.UserInformations.FindAsync(email);

            if (userInformation == null)
            {
                return NotFound();
            }

            return Ok(userInformation);
        }

        // PUT: api/UserInformations/5
        [HttpPut("{email}")]
        public async Task<IActionResult> PutUserInformation([FromRoute] string email, [FromBody] UserInformation userInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (email != userInformation.Email)
            {
                return BadRequest();
            }

            _context.Entry(userInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInformationExists(email))
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

        // POST: api/UserInformations
        [HttpPost]
        public async Task<IActionResult> PostUserInformation([FromBody] UserInformation userInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserInformations.Add(userInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInformation", new { email = userInformation.Email }, userInformation);
        }

        // DELETE: api/UserInformations/5
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteUserInformation([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInformation = await _context.UserInformations.FindAsync(email);
            if (userInformation == null)
            {
                return NotFound();
            }

            _context.UserInformations.Remove(userInformation);
            await _context.SaveChangesAsync();

            return Ok(userInformation);
        }

        private bool UserInformationExists(string email)
        {
            return _context.UserInformations.Any(e => e.Email == email);
        }
    }
}