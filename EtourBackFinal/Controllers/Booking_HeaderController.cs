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
    public class Booking_HeaderController : ControllerBase
    {
        private readonly ETourContext _context;

        public Booking_HeaderController(ETourContext context)
        {
            _context = context;
        }

        // GET: api/Booking_Header
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking_Header>>> GetBookingHeader()
        {
          if (_context.BookingHeader == null)
          {
              return NotFound();
          }

            /*var res = from category in _context.CategoryMaster
                      join cost in _context.CostMaster on category.MasterId equals cost.MasterId
                      select new
                      {
                          category.CategoryId,
                          category.CategoryName,
                          cost

                      };*/
            return await _context.BookingHeader.ToListAsync();
        }

        // GET: api/Booking_Header/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking_Header>> GetBooking_Header(int id)
        {
          if (_context.BookingHeader == null)
          {
              return NotFound();
          }
            var booking_Header = await _context.BookingHeader.FindAsync(id);
            //var res;

            if(booking_Header == null)
            {
                return NotFound();
            }

           /* if (booking_Header == null)
            {
                // return NotFound();
                var res = from category in _context.CategoryMaster
                      join cost in _context.CostMaster on category.MasterId equals cost.MasterId
                      where cost.MasterId == id
                      select new
                      {
                          category.CategoryId,
                          category.CategoryName,
                          cost

                      };
                return Ok(res.ToList());
            }*/
          /*  var res = from category in _context.CategoryMaster
                      join cost in _context.CostMaster on category.MasterId equals cost.MasterId
                      where cost.MasterId == id
                      select new
                      {
                          category.CategoryId,
                          category.CategoryName,
                          cost

                      };*/

            return booking_Header;
        }

        // PUT: api/Booking_Header/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking_Header(int id, Booking_Header booking_Header)
        {
            if (id != booking_Header.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(booking_Header).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Booking_HeaderExists(id))
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

        // POST: api/Booking_Header
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking_Header>> PostBooking_Header(Booking_Header booking_Header)
        {
          if (_context.BookingHeader == null)
          {
              return Problem("Entity set 'ETourContext.BookingHeader'  is null.");
          }
            _context.BookingHeader.Add(booking_Header);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooking_Header", new { id = booking_Header.BookingId }, booking_Header);
        }

        // DELETE: api/Booking_Header/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking_Header(int id)
        {
            if (_context.BookingHeader == null)
            {
                return NotFound();
            }
            var booking_Header = await _context.BookingHeader.FindAsync(id);
            if (booking_Header == null)
            {
                return NotFound();
            }

            _context.BookingHeader.Remove(booking_Header);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Booking_HeaderExists(int id)
        {
            return (_context.BookingHeader?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
