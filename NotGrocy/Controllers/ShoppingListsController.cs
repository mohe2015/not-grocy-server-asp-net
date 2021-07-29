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
    public class ShoppingListsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public ShoppingListsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingList1>>> GetShoppingLists1()
        {
            return await _context.ShoppingLists1.ToListAsync();
        }

        // GET: api/ShoppingLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingList1>> GetShoppingList1(long id)
        {
            var shoppingList1 = await _context.ShoppingLists1.FindAsync(id);

            if (shoppingList1 == null)
            {
                return NotFound();
            }

            return shoppingList1;
        }

        // PUT: api/ShoppingLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingList1(long id, ShoppingList1 shoppingList1)
        {
            if (id != shoppingList1.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingList1).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingList1Exists(id))
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

        // POST: api/ShoppingLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingList1>> PostShoppingList1(ShoppingList1 shoppingList1)
        {
            _context.ShoppingLists1.Add(shoppingList1);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingList1", new { id = shoppingList1.Id }, shoppingList1);
        }

        // DELETE: api/ShoppingLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList1(long id)
        {
            var shoppingList1 = await _context.ShoppingLists1.FindAsync(id);
            if (shoppingList1 == null)
            {
                return NotFound();
            }

            _context.ShoppingLists1.Remove(shoppingList1);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingList1Exists(long id)
        {
            return _context.ShoppingLists1.Any(e => e.Id == id);
        }
    }
}
