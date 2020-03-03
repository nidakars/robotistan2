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
    public class SepetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SepetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sepets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sepet>>> GetSepet()
        {
            return await _context.Sepet.ToListAsync();
        }

        // GET: api/Sepets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sepet>> GetSepet(int id)
        {
            var sepet = await _context.Sepet.FindAsync(id);

            if (sepet == null)
            {
                return NotFound();
            }

            return sepet;
        }

        // PUT: api/Sepets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSepet(int id, Sepet sepet)
        {
            if (id != sepet.Id)
            {
                return BadRequest();
            }

            _context.Entry(sepet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SepetExists(id))
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

        // POST: api/Sepets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Sepet>> PostSepet(Sepet sepet)
        {
            _context.Sepet.Add(sepet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSepet", new { id = sepet.Id }, sepet);
        }

        // DELETE: api/Sepets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sepet>> DeleteSepet(int id)
        {
            var sepet = await _context.Sepet.FindAsync(id);
            if (sepet == null)
            {
                return NotFound();
            }

            _context.Sepet.Remove(sepet);
            await _context.SaveChangesAsync();

            return sepet;
        }

        private bool SepetExists(int id)
        {
            return _context.Sepet.Any(e => e.Id == id);
        }
    }
}
