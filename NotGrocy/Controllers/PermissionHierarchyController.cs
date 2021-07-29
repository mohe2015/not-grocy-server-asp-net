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
    public class PermissionHierarchyController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public PermissionHierarchyController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/PermissionHierarchy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionHierarchy>>> GetPermissionHierarchies()
        {
            return await _context.PermissionHierarchies.ToListAsync();
        }

        // GET: api/PermissionHierarchy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionHierarchy>> GetPermissionHierarchy(long id)
        {
            var permissionHierarchy = await _context.PermissionHierarchies.FindAsync(id);

            if (permissionHierarchy == null)
            {
                return NotFound();
            }

            return permissionHierarchy;
        }

        // PUT: api/PermissionHierarchy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionHierarchy(long id, PermissionHierarchy permissionHierarchy)
        {
            if (id != permissionHierarchy.Id)
            {
                return BadRequest();
            }

            _context.Entry(permissionHierarchy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionHierarchyExists(id))
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

        // POST: api/PermissionHierarchy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PermissionHierarchy>> PostPermissionHierarchy(PermissionHierarchy permissionHierarchy)
        {
            _context.PermissionHierarchies.Add(permissionHierarchy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermissionHierarchy", new { id = permissionHierarchy.Id }, permissionHierarchy);
        }

        // DELETE: api/PermissionHierarchy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionHierarchy(long id)
        {
            var permissionHierarchy = await _context.PermissionHierarchies.FindAsync(id);
            if (permissionHierarchy == null)
            {
                return NotFound();
            }

            _context.PermissionHierarchies.Remove(permissionHierarchy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermissionHierarchyExists(long id)
        {
            return _context.PermissionHierarchies.Any(e => e.Id == id);
        }
    }
}
