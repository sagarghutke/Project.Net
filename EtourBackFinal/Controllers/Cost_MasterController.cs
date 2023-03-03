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
    public class Cost_MasterController : ControllerBase
    {
        private readonly ETourContext _context;

        public Cost_MasterController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Cost_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cost_Master>>> GetCostMaster()
        {
          if (_context.CostMaster == null)
          {
              return NotFound();
          }
            return await _context.CostMaster.ToListAsync();
        }

        // GET: api/Cost_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cost_Master>> GetCost_Master(int id)
        {
          if (_context.CostMaster == null)
          {
              return NotFound();
          }
            var cost_Master = await _context.CostMaster.FindAsync(id);

            if (cost_Master == null)
            {
                return NotFound();
            }

            return cost_Master;
        }

        // PUT: api/Cost_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCost_Master(int id, Cost_Master cost_Master)
        {
            if (id != cost_Master.CostId)
            {
                return BadRequest();
            }

            _context.Entry(cost_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Cost_MasterExists(id))
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

    /*    //GET:api/Cost_Master/200000/250000
        [HttpGet("{minprice}/{maxprice}")]
        public async Task<ActionResult<IEnumerator<Cost_Master>>> Get_CostMaster(double minprice, double maxprice)
        {
            if(_context.CostMaster == null)
            {
                return NotFound();
            }
            var query = from cost in _context.CostMaster
                        join category in _context.CategoryMaster on cost.MasterId equals category.MasterId
                        where cost.Cost >= minprice && cost.Cost<= maxprice
                        select new
                        {
                            category.MasterId,
                            category.SubcategoryId,
                            category.CategoryName,
                            cost.Cost                           
                        };
            var result = await query.ToListAsync();

            return Ok(result);
        }
*/

        // POST: api/Cost_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cost_Master>> PostCost_Master(Cost_Master cost_Master)
        {
          if (_context.CostMaster == null)
          {
              return Problem("Entity set 'ETourContext.CostMaster'  is null.");
          }
            _context.CostMaster.Add(cost_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCost_Master", new { id = cost_Master.CostId }, cost_Master);
        }

        // DELETE: api/Cost_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCost_Master(int id)
        {
            if (_context.CostMaster == null)
            {
                return NotFound();
            }
            var cost_Master = await _context.CostMaster.FindAsync(id);
            if (cost_Master == null)
            {
                return NotFound();
            }

            _context.CostMaster.Remove(cost_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Cost_MasterExists(int id)
        {
            return (_context.CostMaster?.Any(e => e.CostId == id)).GetValueOrDefault();
        }
    }
}
