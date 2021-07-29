using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotGrocy;
using NotGrocy.Models;

namespace NotGrocy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesNestingsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public RecipesNestingsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/RecipesNestings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipesNesting>>> GetRecipesNestings()
        {
            return await _context.RecipesNestings.ToListAsync();
        }

        // GET: api/RecipesNestings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipesNesting>> GetRecipesNesting(long id)
        {
            var recipesNesting = await _context.RecipesNestings.FindAsync(id);

            if (recipesNesting == null)
            {
                return NotFound();
            }

            return recipesNesting;
        }

        // PUT: api/RecipesNestings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipesNesting(long id, RecipesNesting recipesNesting)
        {
            if (id != recipesNesting.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipesNesting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesNestingExists(id))
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

        // POST: api/RecipesNestings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipesNesting>> PostRecipesNesting(RecipesNesting recipesNesting)
        {
            _context.RecipesNestings.Add(recipesNesting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipesNesting", new { id = recipesNesting.Id }, recipesNesting);
        }

        // DELETE: api/RecipesNestings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipesNesting(long id)
        {
            var recipesNesting = await _context.RecipesNestings.FindAsync(id);
            if (recipesNesting == null)
            {
                return NotFound();
            }

            _context.RecipesNestings.Remove(recipesNesting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipesNestingExists(long id)
        {
            return _context.RecipesNestings.Any(e => e.Id == id);
        }
    }
}
