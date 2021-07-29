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
    public class ShoppingLocationsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public ShoppingLocationsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingLocation>>> GetShoppingLocations()
        {
            return await _context.ShoppingLocations.ToListAsync();
        }

        // GET: api/ShoppingLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingLocation>> GetShoppingLocation(long id)
        {
            var shoppingLocation = await _context.ShoppingLocations.FindAsync(id);

            if (shoppingLocation == null)
            {
                return NotFound();
            }

            return shoppingLocation;
        }

        // PUT: api/ShoppingLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingLocation(long id, ShoppingLocation shoppingLocation)
        {
            if (id != shoppingLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingLocationExists(id))
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

        // POST: api/ShoppingLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingLocation>> PostShoppingLocation(ShoppingLocation shoppingLocation)
        {
            _context.ShoppingLocations.Add(shoppingLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingLocation", new { id = shoppingLocation.Id }, shoppingLocation);
        }

        // DELETE: api/ShoppingLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingLocation(long id)
        {
            var shoppingLocation = await _context.ShoppingLocations.FindAsync(id);
            if (shoppingLocation == null)
            {
                return NotFound();
            }

            _context.ShoppingLocations.Remove(shoppingLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingLocationExists(long id)
        {
            return _context.ShoppingLocations.Any(e => e.Id == id);
        }
    }
}
