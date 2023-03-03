using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EtourBackFinal.Model;

namespace EtourBackFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category_MasterController : ControllerBase
    {
        private readonly ETourContext _context;

        public Category_MasterController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Category_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category_Master>>> GetCategoryMaster()
        {
          if (_context.CategoryMaster == null)
          {
              return NotFound();
          }
            return await _context.CategoryMaster.Where((p)=>p.SubCategoryId==null).ToListAsync();
        }

        // GET: api/Category_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Category_Master>>> GetCategory_Master(int id)
        {
          if (_context.CategoryMaster == null)
          {
              return NotFound();
          }
            var category_Master = await _context.CategoryMaster.FindAsync(id);

            if (category_Master == null)
            {
                return NotFound();
            }

            return await _context.CategoryMaster.Where((p) => p.SubCategoryId == category_Master.CategoryId).ToListAsync();
        }

      



        // PUT: api/Category_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory_Master(int id, Category_Master category_Master)
        {
            if (id != category_Master.MasterId)
            {
                return BadRequest();
            }

            _context.Entry(category_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Category_MasterExists(id))
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

        // POST: api/Category_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category_Master>> PostCategory_Master(Category_Master category_Master)
        {
          if (_context.CategoryMaster == null)
          {
              return Problem("Entity set 'ETourContext.CategoryMaster'  is null.");
          }
            _context.CategoryMaster.Add(category_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory_Master", new { id = category_Master.MasterId }, category_Master);
        }

        // DELETE: api/Category_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory_Master(int id)
        {
            if (_context.CategoryMaster == null)
            {
                return NotFound();
            }
            var category_Master = await _context.CategoryMaster.FindAsync(id);
            if (category_Master == null)
            {
                return NotFound();
            }

            _context.CategoryMaster.Remove(category_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Category_MasterExists(int id)
        {
            return (_context.CategoryMaster?.Any(e => e.MasterId == id)).GetValueOrDefault();
        }

    }
}
