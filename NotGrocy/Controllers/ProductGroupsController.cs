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
    public class ProductGroupsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public ProductGroupsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/ProductGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGroup>>> GetProductGroups()
        {
            return await _context.ProductGroups.ToListAsync();
        }

        // GET: api/ProductGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGroup>> GetProductGroup(long id)
        {
            var productGroup = await _context.ProductGroups.FindAsync(id);

            if (productGroup == null)
            {
                return NotFound();
            }

            return productGroup;
        }

        // PUT: api/ProductGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductGroup(long id, ProductGroup productGroup)
        {
            if (id != productGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(productGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductGroupExists(id))
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

        // POST: api/ProductGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductGroup>> PostProductGroup(ProductGroup productGroup)
        {
            _context.ProductGroups.Add(productGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductGroup", new { id = productGroup.Id }, productGroup);
        }

        // DELETE: api/ProductGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductGroup(long id)
        {
            var productGroup = await _context.ProductGroups.FindAsync(id);
            if (productGroup == null)
            {
                return NotFound();
            }

            _context.ProductGroups.Remove(productGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductGroupExists(long id)
        {
            return _context.ProductGroups.Any(e => e.Id == id);
        }
    }
}
