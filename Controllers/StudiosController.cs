﻿using System;
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
    public class StudiosController : Controller
    {
        private readonly CinemaAPIContext _context;

        public StudiosController(CinemaAPIContext context)
        {
            _context = context;
        }

        // GET: api/Studios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studio>>> GetStudios()
        {
            return await _context.Studios.ToListAsync();
        }

        // GET: api/Studios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studio>> GetStudio(int id)
        {
            var studio = await _context.Studios.FindAsync(id);

            if (studio == null)
            {
                return NotFound();
            }

            return studio;
        }

        // PUT: api/Studios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudio(int id, Studio studio)
        {
            if (id != studio.Id)
            {
                return BadRequest();
            }

            _context.Entry(studio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudioExists(id))
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

        // POST: api/Studios
        [HttpPost]
        public async Task<ActionResult<Studio>> PostStudio(Studio studio)
        {
            _context.Studios.Add(studio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudio", new { id = studio.Id }, studio);
        }

        // DELETE: api/Studios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Studio>> DeleteStudio(int id)
        {
            var studio = await _context.Studios.FindAsync(id);
            if (studio == null)
            {
                return NotFound();
            }

            _context.Studios.Remove(studio);
            await _context.SaveChangesAsync();

            return studio;
        }

        private bool StudioExists(int id)
        {
            return _context.Studios.Any(e => e.Id == id);
        }
    }
}