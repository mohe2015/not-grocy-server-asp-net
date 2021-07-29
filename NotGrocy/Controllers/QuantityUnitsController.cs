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
    public class QuantityUnitsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public QuantityUnitsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/QuantityUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuantityUnit>>> GetQuantityUnits()
        {
            return await _context.QuantityUnits.ToListAsync();
        }

        // GET: api/QuantityUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuantityUnit>> GetQuantityUnit(long id)
        {
            var quantityUnit = await _context.QuantityUnits.FindAsync(id);

            if (quantityUnit == null)
            {
                return NotFound();
            }

            return quantityUnit;
        }

        // PUT: api/QuantityUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuantityUnit(long id, QuantityUnit quantityUnit)
        {
            if (id != quantityUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(quantityUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityUnitExists(id))
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

        // POST: api/QuantityUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuantityUnit>> PostQuantityUnit(QuantityUnit quantityUnit)
        {
            _context.QuantityUnits.Add(quantityUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuantityUnit", new { id = quantityUnit.Id }, quantityUnit);
        }

        // DELETE: api/QuantityUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuantityUnit(long id)
        {
            var quantityUnit = await _context.QuantityUnits.FindAsync(id);
            if (quantityUnit == null)
            {
                return NotFound();
            }

            _context.QuantityUnits.Remove(quantityUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuantityUnitExists(long id)
        {
            return _context.QuantityUnits.Any(e => e.Id == id);
        }
    }
}
