using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using robotistan.Domain.Models;
using robotistan.Persistence.Contexts;

namespace robotistan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SiparisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Siparis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Siparis>>> GetSiparis()
        {
            return await _context.Siparis.ToListAsync();
        }

        // GET: api/Siparis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Siparis>> GetSiparis(int id)
        {
            var siparis = await _context.Siparis.FindAsync(id);

            if (siparis == null)
            {
                return NotFound();
            }

            return siparis;
        }

        // PUT: api/Siparis/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSiparis(int id, Siparis siparis)
        {
            if (id != siparis.Id)
            {
                return BadRequest();
            }

            _context.Entry(siparis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiparisExists(id))
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

        // POST: api/Siparis
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Siparis>> PostSiparis(Siparis siparis)
        {
            _context.Siparis.Add(siparis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSiparis", new { id = siparis.Id }, siparis);
        }

        // DELETE: api/Siparis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Siparis>> DeleteSiparis(int id)
        {
            var siparis = await _context.Siparis.FindAsync(id);
            if (siparis == null)
            {
                return NotFound();
            }

            _context.Siparis.Remove(siparis);
            await _context.SaveChangesAsync();

            return siparis;
        }

        private bool SiparisExists(int id)
        {
            return _context.Siparis.Any(e => e.Id == id);
        }
    }
}
