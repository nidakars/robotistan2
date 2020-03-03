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
    public class SlidersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SlidersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sliders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Slider>>> GetSlider()
        {
            return await _context.Slider.ToListAsync();
        }

        // GET: api/Sliders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Slider>> GetSlider(int id)
        {
            var slider = await _context.Slider.FindAsync(id);

            if (slider == null)
            {
                return NotFound();
            }

            return slider;
        }

        // PUT: api/Sliders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSlider(int id, Slider slider)
        {
            if (id != slider.Id)
            {
                return BadRequest();
            }

            _context.Entry(slider).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SliderExists(id))
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

        // POST: api/Sliders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Slider>> PostSlider(Slider slider)
        {
            _context.Slider.Add(slider);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSlider", new { id = slider.Id }, slider);
        }

        // DELETE: api/Sliders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Slider>> DeleteSlider(int id)
        {
            var slider = await _context.Slider.FindAsync(id);
            if (slider == null)
            {
                return NotFound();
            }

            _context.Slider.Remove(slider);
            await _context.SaveChangesAsync();

            return slider;
        }

        private bool SliderExists(int id)
        {
            return _context.Slider.Any(e => e.Id == id);
        }
    }
}
