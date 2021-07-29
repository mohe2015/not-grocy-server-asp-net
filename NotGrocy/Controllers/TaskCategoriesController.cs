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
    public class TaskCategoriesController : ControllerBase
    {
        private readonly NotGrocyContext _context;

        public TaskCategoriesController(NotGrocyContext context)
        {
            _context = context;
        }

        // GET: api/TaskCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskCategory>>> GetTaskCategories()
        {
            return await _context.TaskCategories.ToListAsync();
        }

        // GET: api/TaskCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskCategory>> GetTaskCategory(long id)
        {
            var taskCategory = await _context.TaskCategories.FindAsync(id);

            if (taskCategory == null)
            {
                return NotFound();
            }

            return taskCategory;
        }

        // PUT: api/TaskCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskCategory(long id, TaskCategory taskCategory)
        {
            if (id != taskCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskCategoryExists(id))
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

        // POST: api/TaskCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskCategory>> PostTaskCategory(TaskCategory taskCategory)
        {
            _context.TaskCategories.Add(taskCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskCategory", new { id = taskCategory.Id }, taskCategory);
        }

        // DELETE: api/TaskCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskCategory(long id)
        {
            var taskCategory = await _context.TaskCategories.FindAsync(id);
            if (taskCategory == null)
            {
                return NotFound();
            }

            _context.TaskCategories.Remove(taskCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskCategoryExists(long id)
        {
            return _context.TaskCategories.Any(e => e.Id == id);
        }
    }
}
