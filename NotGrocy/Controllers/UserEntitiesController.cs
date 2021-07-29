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
    public class UserEntitiesController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public UserEntitiesController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/UserEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userentity>>> GetUserentities()
        {
            return await _context.Userentities.ToListAsync();
        }

        // GET: api/UserEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userentity>> GetUserentity(long id)
        {
            var userentity = await _context.Userentities.FindAsync(id);

            if (userentity == null)
            {
                return NotFound();
            }

            return userentity;
        }

        // PUT: api/UserEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserentity(long id, Userentity userentity)
        {
            if (id != userentity.Id)
            {
                return BadRequest();
            }

            _context.Entry(userentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserentityExists(id))
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

        // POST: api/UserEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userentity>> PostUserentity(Userentity userentity)
        {
            _context.Userentities.Add(userentity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserentity", new { id = userentity.Id }, userentity);
        }

        // DELETE: api/UserEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserentity(long id)
        {
            var userentity = await _context.Userentities.FindAsync(id);
            if (userentity == null)
            {
                return NotFound();
            }

            _context.Userentities.Remove(userentity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserentityExists(long id)
        {
            return _context.Userentities.Any(e => e.Id == id);
        }
    }
}
