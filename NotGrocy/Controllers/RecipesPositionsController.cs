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
    public class RecipesPositionsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public RecipesPositionsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/RecipesPositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipesPo>>> GetRecipesPos()
        {
            return await _context.RecipesPos.ToListAsync();
        }

        // GET: api/RecipesPositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipesPo>> GetRecipesPo(long id)
        {
            var recipesPo = await _context.RecipesPos.FindAsync(id);

            if (recipesPo == null)
            {
                return NotFound();
            }

            return recipesPo;
        }

        // PUT: api/RecipesPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipesPo(long id, RecipesPo recipesPo)
        {
            if (id != recipesPo.Id)
            {
                return BadRequest();
            }

            _context.Entry(recipesPo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesPoExists(id))
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

        // POST: api/RecipesPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipesPo>> PostRecipesPo(RecipesPo recipesPo)
        {
            _context.RecipesPos.Add(recipesPo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecipesPo", new { id = recipesPo.Id }, recipesPo);
        }

        // DELETE: api/RecipesPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipesPo(long id)
        {
            var recipesPo = await _context.RecipesPos.FindAsync(id);
            if (recipesPo == null)
            {
                return NotFound();
            }

            _context.RecipesPos.Remove(recipesPo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipesPoExists(long id)
        {
            return _context.RecipesPos.Any(e => e.Id == id);
        }
    }
}
