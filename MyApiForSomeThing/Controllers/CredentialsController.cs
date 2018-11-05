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
    public class CredentialsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public CredentialsController(MyApiContext context)
        {
            _context = context;
        }

        // GET: api/Credentials
        [HttpGet]
        public IEnumerable<Credential> GetCredentials()
        {
            return _context.Credentials;
        }

        // GET: api/Credentials/5
        [HttpGet("{token}")]
        public async Task<IActionResult> GetCredential([FromRoute] string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var credential = await _context.Credentials.FindAsync(token);

            if (credential == null)
            {
                return NotFound();
            }

            return Ok(credential);
        }

        // PUT: api/Credentials/5
        [HttpPut("{token}")]
        public async Task<IActionResult> PutCredential([FromRoute] string token, [FromBody] Credential credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (token != credential.Token)
            {
                return BadRequest();
            }

            _context.Entry(credential).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CredentialExists(token))
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

        // POST: api/Credentials
        [HttpPost]
        public async Task<IActionResult> PostCredential([FromBody] Credential credential)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            _context.Credentials.Add(credential);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCredential", new { token = credential.Token }, credential);
        }

        // DELETE: api/Credentials/5
        [HttpDelete("{token}")]
        public async Task<IActionResult> DeleteCredential([FromRoute] string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var credential = await _context.Credentials.FindAsync(token);
            if (credential == null)
            {
                return NotFound();
            }

            _context.Credentials.Remove(credential);
            await _context.SaveChangesAsync();

            return Ok(credential);
        }

        private bool CredentialExists(string token)
        {
            return _context.Credentials.Any(e => e.Token == token);
        }
    }
}