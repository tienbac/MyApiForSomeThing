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
    public class RoleCredentialsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public RoleCredentialsController(MyApiContext context)
        {
            _context = context;
        }

        // GET: api/RoleCredentials
        [HttpGet]
        public IEnumerable<RoleCredential> GetAllRoleCredentials()
        {
            return _context.RoleCredentials;
        }

        // GET: api/RoleCredentials/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRoleCredential([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleCredential = await _context.RoleCredentials.FindAsync(id);
            if (roleCredential == null)
            {
                return NotFound();
            }

            return Ok(roleCredential);
        }

        // PUT: api/RoleCredentials/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleCredential([FromRoute] long id,
            [FromBody] RoleCredential roleCredential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleCredential.RId)
            {
                return BadRequest();
            }

            _context.Entry(roleCredential).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!RoleCredentialExists(id))
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
        
        // POST: api/RoleCredentials
        [HttpPost]
        public async Task<IActionResult> CreateRoleCredential([FromBody] RoleCredential roleCredential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RoleCredentials.Add(roleCredential);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneRoleCredential", new {id = roleCredential.RId}, roleCredential);
        }

        // DELETE: api/RoleCredentials/{id}
        public async Task<IActionResult> DeleteRoleCredential([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleCredential = await _context.RoleCredentials.FindAsync(id);
            if (roleCredential == null)
            {
                return NotFound();
            }

            _context.RoleCredentials.Remove(roleCredential);
            await _context.SaveChangesAsync();

            return Ok(roleCredential);
        }

        public bool RoleCredentialExists(long id)
        {
            return _context.RoleCredentials.Any(role => role.RId == id);
        }
    }
}