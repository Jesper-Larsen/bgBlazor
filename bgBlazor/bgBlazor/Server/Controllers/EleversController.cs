#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bgBlazor.Server.Models;
using bgBlazor.Shared.Models;

namespace bgBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleversController : ControllerBase
    {
        private readonly bgBlazorContext _context;

        public EleversController(bgBlazorContext context)
        {
            _context = context;
        }

        // GET: api/Elevers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elever>>> GetElevers()
        {
            return await _context.Elevers.ToListAsync();
        }

        // GET: api/Elevers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elever>> GetElever(int id)
        {
            var elever = await _context.Elevers.FindAsync(id);

            if (elever == null)
            {
                return NotFound();
            }

            return elever;
        }

        // PUT: api/Elevers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElever(int id, Elever elever)
        {
            if (id != elever.Id)
            {
                return BadRequest();
            }

            _context.Entry(elever).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EleverExists(id))
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

        // POST: api/Elevers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elever>> PostElever(Elever elever)
        {
            _context.Elevers.Add(elever);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElever", new { id = elever.Id }, elever);
        }

        // DELETE: api/Elevers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElever(int id)
        {
            var elever = await _context.Elevers.FindAsync(id);
            if (elever == null)
            {
                return NotFound();
            }

            _context.Elevers.Remove(elever);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EleverExists(int id)
        {
            return _context.Elevers.Any(e => e.Id == id);
        }
    }
}
