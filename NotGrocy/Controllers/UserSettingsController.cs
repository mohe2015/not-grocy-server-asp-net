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
    public class UserSettingsController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public UserSettingsController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/UserSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSetting>>> GetUserSettings()
        {
            return await _context.UserSettings.ToListAsync();
        }

        // GET: api/UserSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSetting>> GetUserSetting(long id)
        {
            var userSetting = await _context.UserSettings.FindAsync(id);

            if (userSetting == null)
            {
                return NotFound();
            }

            return userSetting;
        }

        // PUT: api/UserSettings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSetting(long id, UserSetting userSetting)
        {
            if (id != userSetting.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSetting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSettingExists(id))
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

        // POST: api/UserSettings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSetting>> PostUserSetting(UserSetting userSetting)
        {
            _context.UserSettings.Add(userSetting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSetting", new { id = userSetting.Id }, userSetting);
        }

        // DELETE: api/UserSettings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSetting(long id)
        {
            var userSetting = await _context.UserSettings.FindAsync(id);
            if (userSetting == null)
            {
                return NotFound();
            }

            _context.UserSettings.Remove(userSetting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSettingExists(long id)
        {
            return _context.UserSettings.Any(e => e.Id == id);
        }
    }
}
