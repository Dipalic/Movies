using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTablesController : ControllerBase
    {
        private readonly MoviesContext _context;

        public MovieTablesController(MoviesContext context)
        {
            _context = context;
        }

        // GET: api/MovieTables
        [HttpGet]
        public IEnumerable<MovieTable> GetMovieTable()
        {
            return _context.MovieTable;
        }

        // GET: api/MovieTables/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieTable = await _context.MovieTable.FindAsync(id);

            if (movieTable == null)
            {
                return NotFound();
            }

            return Ok(movieTable);
        }

        // PUT: api/MovieTables/5
        [HttpPut("{movieId}")]
        public async Task<IActionResult> PutMovieTable([FromRoute] int movieId, [FromBody] MovieTable movieTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (movieId != movieTable.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movieTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieTableExists(movieId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(movieTable);
        }

        // POST: api/MovieTables
        [HttpPost]
        public async Task<IActionResult> PostMovieTable([FromBody] MovieTable movieTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MovieTable.Add(movieTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovieTable", new { id = movieTable.MovieId }, movieTable);
        }

        // DELETE: api/MovieTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieTable([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieTable = await _context.MovieTable.FindAsync(id);
            if (movieTable == null)
            {
                return NotFound();
            }

            _context.MovieTable.Remove(movieTable);
            await _context.SaveChangesAsync();

            return Ok(movieTable);
        }

        private bool MovieTableExists(int id)
        {
            return _context.MovieTable.Any(e => e.MovieId == id);
        }
    }
}