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
    public class Date_MasterController : ControllerBase
    {
        private readonly ETourContext _context;

        public Date_MasterController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Date_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Date_Master>>> GetDateMaster()
        {
          if (_context.DateMaster == null)
          {
              return NotFound();
          }
            return await _context.DateMaster.ToListAsync();
        }

        // GET: api/Date_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Date_Master>> GetDate_Master(int id)
        {
          if (_context.DateMaster == null)
          {
              return NotFound();
          }
            var date_Master = await _context.DateMaster.FindAsync(id);

            if (date_Master == null)
            {
                return NotFound();
            }

            return date_Master;
        }
/*
        //GET:api/Date_Master/2022-12-24/2023-04-25
        [HttpGet("{startdate}/{enddate}")]
        public async Task<ActionResult<Date_Master>> GetDate_Master(DateTime startdate , DateTime enddate)
        {
            if(_context.DateMaster == null)
            {
                return NotFound();
            }
            var res = from date in _context.DateMaster
                      join category in _context.CategoryMaster on date.MasterId equals category.MasterId
                      where date.DepartureDate == startdate || date.EndDate == enddate
                      select new 
                      {
                          category
                      };
            return Ok(res.ToList());

        }*/

        // PUT: api/Date_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDate_Master(int id, Date_Master date_Master)
        {
            if (id != date_Master.DepartureId)
            {
                return BadRequest();
            }

            _context.Entry(date_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Date_MasterExists(id))
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

        // POST: api/Date_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Date_Master>> PostDate_Master(Date_Master date_Master)
        {
          if (_context.DateMaster == null)
          {
              return Problem("Entity set 'ETourContext.DateMaster'  is null.");
          }
            _context.DateMaster.Add(date_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDate_Master", new { id = date_Master.DepartureId }, date_Master);
        }

        // DELETE: api/Date_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDate_Master(int id)
        {
            if (_context.DateMaster == null)
            {
                return NotFound();
            }
            var date_Master = await _context.DateMaster.FindAsync(id);
            if (date_Master == null)
            {
                return NotFound();
            }

            _context.DateMaster.Remove(date_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Date_MasterExists(int id)
        {
            return (_context.DateMaster?.Any(e => e.DepartureId == id)).GetValueOrDefault();
        }
    }
}
