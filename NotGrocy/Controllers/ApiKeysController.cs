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
    public class ApiKeysController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public ApiKeysController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/ApiKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApiKey>>> GetApiKeys()
        {
            return await _context.ApiKeys.ToListAsync();
            //return await _context.ApiKeys.Include(k => k.User).ToListAsync();
        }

        // GET: api/ApiKeys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiKey>> GetApiKey(long id)
        {
            var apiKey = await _context.ApiKeys.FindAsync(id);

            if (apiKey == null)
            {
                return NotFound();
            }

            return apiKey;
        }

        // PUT: api/ApiKeys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApiKey(long id, ApiKey apiKey)
        {
            if (id != apiKey.Id)
            {
                return BadRequest();
            }

            _context.Entry(apiKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApiKeyExists(id))
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

        // POST: api/ApiKeys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiKey>> PostApiKey(ApiKey apiKey)
        {
            _context.ApiKeys.Add(apiKey);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApiKey", new { id = apiKey.Id }, apiKey);
        }

        // DELETE: api/ApiKeys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApiKey(long id)
        {
            var apiKey = await _context.ApiKeys.FindAsync(id);
            if (apiKey == null)
            {
                return NotFound();
            }

            _context.ApiKeys.Remove(apiKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApiKeyExists(long id)
        {
            return _context.ApiKeys.Any(e => e.Id == id);
        }
    }
}
