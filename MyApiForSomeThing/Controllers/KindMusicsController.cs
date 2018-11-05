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
    public class KindMusicsController : ControllerBase
    {
        private readonly MyApiContext _context;

        public KindMusicsController(MyApiContext context)
        {
            _context = context;
        }

        // GET: api/KindMusics
        [HttpGet]
        public IEnumerable<KindMusic> GetKindMusics()
        {
            return _context.KindMusics;
        }

        // GET: api/KindMusics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKindMusic([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kindMusic = await _context.KindMusics.FindAsync(id);

            if (kindMusic == null)
            {
                return NotFound();
            }

            return Ok(kindMusic);
        }

        // PUT: api/KindMusics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKindMusic([FromRoute] long id, [FromBody] KindMusic kindMusic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kindMusic.KId)
            {
                return BadRequest();
            }

            _context.Entry(kindMusic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KindMusicExists(id))
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

        // POST: api/KindMusics
        [HttpPost]
        public async Task<IActionResult> PostKindMusic([FromBody] KindMusic kindMusic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.KindMusics.Add(kindMusic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKindMusic", new { id = kindMusic.KId }, kindMusic);
        }

        // DELETE: api/KindMusics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKindMusic([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kindMusic = await _context.KindMusics.FindAsync(id);
            if (kindMusic == null)
            {
                return NotFound();
            }

            _context.KindMusics.Remove(kindMusic);
            await _context.SaveChangesAsync();

            return Ok(kindMusic);
        }

        private bool KindMusicExists(long id)
        {
            return _context.KindMusics.Any(e => e.KId == id);
        }
    }
}