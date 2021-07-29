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
    public class UserPermissionsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public UserPermissionsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/UserPermissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPermission>>> GetUserPermissions()
        {
            return await _context.UserPermissions.ToListAsync();
        }

        // GET: api/UserPermissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPermission>> GetUserPermission(long id)
        {
            var userPermission = await _context.UserPermissions.FindAsync(id);

            if (userPermission == null)
            {
                return NotFound();
            }

            return userPermission;
        }

        // PUT: api/UserPermissions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPermission(long id, UserPermission userPermission)
        {
            if (id != userPermission.Id)
            {
                return BadRequest();
            }

            _context.Entry(userPermission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPermissionExists(id))
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

        // POST: api/UserPermissions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPermission>> PostUserPermission(UserPermission userPermission)
        {
            _context.UserPermissions.Add(userPermission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPermission", new { id = userPermission.Id }, userPermission);
        }

        // DELETE: api/UserPermissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPermission(long id)
        {
            var userPermission = await _context.UserPermissions.FindAsync(id);
            if (userPermission == null)
            {
                return NotFound();
            }

            _context.UserPermissions.Remove(userPermission);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPermissionExists(long id)
        {
            return _context.UserPermissions.Any(e => e.Id == id);
        }
    }
}
