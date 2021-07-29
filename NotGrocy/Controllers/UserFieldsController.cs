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
    public class UserFieldsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public UserFieldsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/UserFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userfield>>> GetUserfields()
        {
            return await _context.Userfields.ToListAsync();
        }

        // GET: api/UserFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userfield>> GetUserfield(long id)
        {
            var userfield = await _context.Userfields.FindAsync(id);

            if (userfield == null)
            {
                return NotFound();
            }

            return userfield;
        }

        // PUT: api/UserFields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserfield(long id, Userfield userfield)
        {
            if (id != userfield.Id)
            {
                return BadRequest();
            }

            _context.Entry(userfield).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserfieldExists(id))
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

        // POST: api/UserFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userfield>> PostUserfield(Userfield userfield)
        {
            _context.Userfields.Add(userfield);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserfield", new { id = userfield.Id }, userfield);
        }

        // DELETE: api/UserFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserfield(long id)
        {
            var userfield = await _context.Userfields.FindAsync(id);
            if (userfield == null)
            {
                return NotFound();
            }

            _context.Userfields.Remove(userfield);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserfieldExists(long id)
        {
            return _context.Userfields.Any(e => e.Id == id);
        }
    }
}
