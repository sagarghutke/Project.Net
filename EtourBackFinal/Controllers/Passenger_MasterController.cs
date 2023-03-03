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
    public class Passenger_MasterController : ControllerBase
    {
        private readonly ETourContext _context;

        public Passenger_MasterController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Passenger_Master
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger_Master>>> GetPassengers()
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            return await _context.Passengers.ToListAsync();
        }

        // GET: api/Passenger_Master/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger_Master>> GetPassenger_Master(int id)
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            var customer_Master = await _context.CustomerMaster.FindAsync(id);
/*
            if(customer_Master != null) 
            {
                var passenger_Master = await _context.Passengers.Where((p) => p.CustomerId == customer_Master.CustomerId).ToListAsync();
                if (passenger_Master == null)
                {
                    return NotFound();
                }
                return Ok(passenger_Master);
            }*/

            return BadRequest("Passenger dosent exist");
           
        }

        //GET:api/Passenger_Master/1/2022-02-22
        [HttpGet("{id}/{date}")]
        public async Task<ActionResult<Passenger_Master>> GetPassenger_Master(int id , DateTime date)
        {
            if(_context.Passengers ==  null)
            {
                return NotFound();
            }

            var passenger_Master  = await _context.Passengers.Where((p)=> p.BookingId == id ).FirstOrDefaultAsync();

            /*if(passenger_Master ==  null)
            {
                return NotFound();
            }*/

            return Ok(passenger_Master);
        }





        // PUT: api/Passenger_Master/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger_Master(int id, Passenger_Master passenger_Master)
        {
            if (id != passenger_Master.PassengerId)
            {
                return BadRequest();
            }

            _context.Entry(passenger_Master).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Passenger_MasterExists(id))
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

        // POST: api/Passenger_Master
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passenger_Master>> PostPassenger_Master(Passenger_Master passenger_Master)
        {
          if (_context.Passengers == null)
          {
              return Problem("Entity set 'ETourContext.Passengers'  is null.");
          }
            _context.Passengers.Add(passenger_Master);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassenger_Master", new { id = passenger_Master.PassengerId }, passenger_Master);
        }

        // DELETE: api/Passenger_Master/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger_Master(int id)
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            var passenger_Master = await _context.Passengers.FindAsync(id);
            if (passenger_Master == null)
            {
                return NotFound();
            }

            _context.Passengers.Remove(passenger_Master);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Passenger_MasterExists(int id)
        {
            return (_context.Passengers?.Any(e => e.PassengerId == id)).GetValueOrDefault();
        }
    }
}
