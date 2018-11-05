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
    public class RoleUsersController : ControllerBase
    {
        private readonly MyApiContext _context;

        public RoleUsersController(MyApiContext context)
        {
            _context = context;
        }

        // GET: api/RoleUsers
        [HttpGet]
        public IEnumerable<RoleUser> GetAllRoleUsers()
        {
            return _context.RoleUsers;
        }

        // GET: api/RoleUsers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneRoleUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleUser = await _context.RoleUsers.FindAsync(id);
            if (roleUser == null)
            {
                return NotFound();
            }

            return Ok(roleUser);
        }

        // PUT: api/RoleUsers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoleUser([FromRoute] long id, [FromBody] RoleUser roleUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleUser.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleUser).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (!RoleUserExists(id))
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

        // POST: api/RoleUsers
        [HttpPost]
        public async Task<IActionResult> CreateRoleUser([FromBody] RoleUser roleUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.RoleUsers.Add(roleUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOneRoleUser", new {id = roleUser.RoleId}, roleUser);
        }

        // DELETE: api/RoleUsers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeteleRoleUser([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleUser = await _context.RoleUsers.FindAsync(id);
            if (roleUser == null)
            {
                return NotFound();
            }

            _context.RoleUsers.Remove(roleUser);
            await _context.SaveChangesAsync();
            return Ok(roleUser);
        }

        public bool RoleUserExists(long id)
        {
            return _context.RoleUsers.Any(role => role.RoleId == id);
        }
    }
}