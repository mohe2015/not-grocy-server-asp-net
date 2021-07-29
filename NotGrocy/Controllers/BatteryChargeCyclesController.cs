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
    public class BatteryChargeCyclesController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public BatteryChargeCyclesController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/BatteryChargeCycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryChargeCycle>>> GetBatteryChargeCycles()
        {
            return await _context.BatteryChargeCycles.ToListAsync();
        }

        // GET: api/BatteryChargeCycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryChargeCycle>> GetBatteryChargeCycle(long id)
        {
            var batteryChargeCycle = await _context.BatteryChargeCycles.FindAsync(id);

            if (batteryChargeCycle == null)
            {
                return NotFound();
            }

            return batteryChargeCycle;
        }

        // PUT: api/BatteryChargeCycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBatteryChargeCycle(long id, BatteryChargeCycle batteryChargeCycle)
        {
            if (id != batteryChargeCycle.Id)
            {
                return BadRequest();
            }

            _context.Entry(batteryChargeCycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryChargeCycleExists(id))
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

        // POST: api/BatteryChargeCycles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BatteryChargeCycle>> PostBatteryChargeCycle(BatteryChargeCycle batteryChargeCycle)
        {
            _context.BatteryChargeCycles.Add(batteryChargeCycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatteryChargeCycle", new { id = batteryChargeCycle.Id }, batteryChargeCycle);
        }

        // DELETE: api/BatteryChargeCycles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBatteryChargeCycle(long id)
        {
            var batteryChargeCycle = await _context.BatteryChargeCycles.FindAsync(id);
            if (batteryChargeCycle == null)
            {
                return NotFound();
            }

            _context.BatteryChargeCycles.Remove(batteryChargeCycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BatteryChargeCycleExists(long id)
        {
            return _context.BatteryChargeCycles.Any(e => e.Id == id);
        }
    }
}
