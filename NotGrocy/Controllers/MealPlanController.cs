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
    public class MealPlanController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public MealPlanController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/MealPlan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealPlan>>> GetMealPlans()
        {
            return await _context.MealPlans.ToListAsync();
        }

        // GET: api/MealPlan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealPlan>> GetMealPlan(long id)
        {
            var mealPlan = await _context.MealPlans.FindAsync(id);

            if (mealPlan == null)
            {
                return NotFound();
            }

            return mealPlan;
        }

        // PUT: api/MealPlan/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealPlan(long id, MealPlan mealPlan)
        {
            if (id != mealPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(mealPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPlanExists(id))
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

        // POST: api/MealPlan
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MealPlan>> PostMealPlan(MealPlan mealPlan)
        {
            _context.MealPlans.Add(mealPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealPlan", new { id = mealPlan.Id }, mealPlan);
        }

        // DELETE: api/MealPlan/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealPlan(long id)
        {
            var mealPlan = await _context.MealPlans.FindAsync(id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            _context.MealPlans.Remove(mealPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MealPlanExists(long id)
        {
            return _context.MealPlans.Any(e => e.Id == id);
        }
    }
}
