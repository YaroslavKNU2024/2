using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalCinema.Models;

namespace FinalCinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmStudioSeancesController : Controller
    {
        private readonly CinemaAPIContext _context;

        public FilmStudioSeancesController(CinemaAPIContext context)
        {
            _context = context;
        }

        // GET: api/FilmStudioSeances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmStudioSeance>>> GetFilmStudioSeances()
        {
            return await _context.FilmStudioSeances.ToListAsync();
        }

        // GET: api/FilmStudioSeances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmStudioSeance>> GetFilmStudioSeance(int id)
        {
            var filmStudioSeance = await _context.FilmStudioSeances.FindAsync(id);

            if (filmStudioSeance == null)
                return NotFound();

            return filmStudioSeance;
        }

        // PUT: api/FilmStudioSeances/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmStudioSeance(int id, FilmStudioSeance filmStudioSeance)
        {
            if (id != filmStudioSeance.Id)
                return BadRequest();

            _context.Entry(filmStudioSeance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmStudioSeanceExists(id))
                    return NotFound();
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FilmStudioSeances
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FilmStudioSeance>> PostFilmStudioSeance(FilmStudioSeance filmStudioSeance)
        {
            _context.FilmStudioSeances.Add(filmStudioSeance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmStudioSeance", new { id = filmStudioSeance.Id }, filmStudioSeance);
        }

        // DELETE: api/FilmStudioSeances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmStudioSeance>> DeleteFilmStudioSeance(int id)
        {
            var filmStudioSeance = await _context.FilmStudioSeances.FindAsync(id);
            if (filmStudioSeance == null)
                return NotFound();

            _context.FilmStudioSeances.Remove(filmStudioSeance);
            await _context.SaveChangesAsync();

            return filmStudioSeance;
        }

        private bool FilmStudioSeanceExists(int id)
        {
            return _context.FilmStudioSeances.Any(e => e.Id == id);
        }
    }
}
