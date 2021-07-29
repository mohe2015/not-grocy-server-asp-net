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
    public class UserobjectsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public UserobjectsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/Userobjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userobject>>> GetUserobjects()
        {
            return await _context.Userobjects.ToListAsync();
        }

        // GET: api/Userobjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userobject>> GetUserobject(long id)
        {
            var userobject = await _context.Userobjects.FindAsync(id);

            if (userobject == null)
            {
                return NotFound();
            }

            return userobject;
        }

        // PUT: api/Userobjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserobject(long id, Userobject userobject)
        {
            if (id != userobject.Id)
            {
                return BadRequest();
            }

            _context.Entry(userobject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserobjectExists(id))
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

        // POST: api/Userobjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userobject>> PostUserobject(Userobject userobject)
        {
            _context.Userobjects.Add(userobject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserobject", new { id = userobject.Id }, userobject);
        }

        // DELETE: api/Userobjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserobject(long id)
        {
            var userobject = await _context.Userobjects.FindAsync(id);
            if (userobject == null)
            {
                return NotFound();
            }

            _context.Userobjects.Remove(userobject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserobjectExists(long id)
        {
            return _context.Userobjects.Any(e => e.Id == id);
        }
    }
}
