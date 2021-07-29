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
    public class QuantityUnitConversionsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public QuantityUnitConversionsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/QuantityUnitConversions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuantityUnitConversion>>> GetQuantityUnitConversions()
        {
            return await _context.QuantityUnitConversions.ToListAsync();
        }

        // GET: api/QuantityUnitConversions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuantityUnitConversion>> GetQuantityUnitConversion(long id)
        {
            var quantityUnitConversion = await _context.QuantityUnitConversions.FindAsync(id);

            if (quantityUnitConversion == null)
            {
                return NotFound();
            }

            return quantityUnitConversion;
        }

        // PUT: api/QuantityUnitConversions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuantityUnitConversion(long id, QuantityUnitConversion quantityUnitConversion)
        {
            if (id != quantityUnitConversion.Id)
            {
                return BadRequest();
            }

            _context.Entry(quantityUnitConversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityUnitConversionExists(id))
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

        // POST: api/QuantityUnitConversions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuantityUnitConversion>> PostQuantityUnitConversion(QuantityUnitConversion quantityUnitConversion)
        {
            _context.QuantityUnitConversions.Add(quantityUnitConversion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuantityUnitConversion", new { id = quantityUnitConversion.Id }, quantityUnitConversion);
        }

        // DELETE: api/QuantityUnitConversions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuantityUnitConversion(long id)
        {
            var quantityUnitConversion = await _context.QuantityUnitConversions.FindAsync(id);
            if (quantityUnitConversion == null)
            {
                return NotFound();
            }

            _context.QuantityUnitConversions.Remove(quantityUnitConversion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuantityUnitConversionExists(long id)
        {
            return _context.QuantityUnitConversions.Any(e => e.Id == id);
        }
    }
}
