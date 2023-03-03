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
    public class Itnerary_MasterController : ControllerBase
    {
        private readonly ETourContext _context;

        public Itnerary_MasterController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Itnerary_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itnerary_Master>>> GetItneraryMaster()
        {
          if (_context.ItneraryMaster == null)
          {
              return NotFound();
          }
            return await _context.ItneraryMaster.ToListAsync();
        }

        // GET: api/Itnerary_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itnerary_Master>> GetItnerary_Master(int id)
        {
          if (_context.ItneraryMaster == null)
          {
              return NotFound();
          }
            //var itnerary_Master = await _context.ItneraryMaster.FindAsync(id);

            var res = from itinerary in _context.ItneraryMaster
                      join category in _context.CategoryMaster on itinerary.MasterId equals category.MasterId
                      join cost in _context.CostMaster on itinerary.MasterId equals cost.MasterId
                      join date in _context.DateMaster on itinerary.MasterId equals date.MasterId
                      where itinerary.MasterId == id
                      select new
                      {
                          itinerary,
                          cost.SinglePersonCost,
                          cost.ExtraPersonCost,
                          cost.ChildWithBed,
                          cost.ChildWithoutBed,
                          cost.ValidFrom,
                          cost.ValidTo,
                          category.CategoryImage,
                          category.CategoryName,
                          category.MasterId,
                          date.DepartureDate,
                          date.DepartureId,
                          date.EndDate
                      };
/*
            if (itnerary_Master == null)
            {
                return NotFound();
            }*/

            return Ok(res.ToList());
        }

        // PUT: api/Itnerary_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItnerary_Master(int id, Itnerary_Master itnerary_Master)
        {
            if (id != itnerary_Master.ItneraryId)
            {
                return BadRequest();
            }

            _context.Entry(itnerary_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Itnerary_MasterExists(id))
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

        // POST: api/Itnerary_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itnerary_Master>> PostItnerary_Master(Itnerary_Master itnerary_Master)
        {
          if (_context.ItneraryMaster == null)
          {
              return Problem("Entity set 'ETourContext.ItneraryMaster'  is null.");
          }
            _context.ItneraryMaster.Add(itnerary_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItnerary_Master", new { id = itnerary_Master.ItneraryId }, itnerary_Master);
        }

        // DELETE: api/Itnerary_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItnerary_Master(int id)
        {
            if (_context.ItneraryMaster == null)
            {
                return NotFound();
            }
            var itnerary_Master = await _context.ItneraryMaster.FindAsync(id);
            if (itnerary_Master == null)
            {
                return NotFound();
            }

            _context.ItneraryMaster.Remove(itnerary_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Itnerary_MasterExists(int id)
        {
            return (_context.ItneraryMaster?.Any(e => e.ItneraryId == id)).GetValueOrDefault();
        }
    }
}
