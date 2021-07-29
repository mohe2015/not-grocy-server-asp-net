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
    public class StockLogController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public StockLogController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/StockLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockLog>>> GetStockLogs()
        {
            return await _context.StockLogs.ToListAsync();
        }

        // GET: api/StockLog/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockLog>> GetStockLog(long id)
        {
            var stockLog = await _context.StockLogs.FindAsync(id);

            if (stockLog == null)
            {
                return NotFound();
            }

            return stockLog;
        }

        // PUT: api/StockLog/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockLog(long id, StockLog stockLog)
        {
            if (id != stockLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockLogExists(id))
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

        // POST: api/StockLog
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockLog>> PostStockLog(StockLog stockLog)
        {
            _context.StockLogs.Add(stockLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockLog", new { id = stockLog.Id }, stockLog);
        }

        // DELETE: api/StockLog/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockLog(long id)
        {
            var stockLog = await _context.StockLogs.FindAsync(id);
            if (stockLog == null)
            {
                return NotFound();
            }

            _context.StockLogs.Remove(stockLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockLogExists(long id)
        {
            return _context.StockLogs.Any(e => e.Id == id);
        }
    }
}
