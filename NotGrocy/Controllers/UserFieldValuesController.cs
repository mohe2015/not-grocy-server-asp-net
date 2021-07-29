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
    public class UserFieldValuesController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public UserFieldValuesController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/UserFieldValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserfieldValue>>> GetUserfieldValues()
        {
            return await _context.UserfieldValues.ToListAsync();
        }

        // GET: api/UserFieldValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserfieldValue>> GetUserfieldValue(long id)
        {
            var userfieldValue = await _context.UserfieldValues.FindAsync(id);

            if (userfieldValue == null)
            {
                return NotFound();
            }

            return userfieldValue;
        }

        // PUT: api/UserFieldValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserfieldValue(long id, UserfieldValue userfieldValue)
        {
            if (id != userfieldValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(userfieldValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserfieldValueExists(id))
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

        // POST: api/UserFieldValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserfieldValue>> PostUserfieldValue(UserfieldValue userfieldValue)
        {
            _context.UserfieldValues.Add(userfieldValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserfieldValue", new { id = userfieldValue.Id }, userfieldValue);
        }

        // DELETE: api/UserFieldValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserfieldValue(long id)
        {
            var userfieldValue = await _context.UserfieldValues.FindAsync(id);
            if (userfieldValue == null)
            {
                return NotFound();
            }

            _context.UserfieldValues.Remove(userfieldValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserfieldValueExists(long id)
        {
            return _context.UserfieldValues.Any(e => e.Id == id);
        }
    }
}
