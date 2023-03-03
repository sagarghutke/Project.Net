/*using EtourBackFinal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EtourBackFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
       *//* private ILogger logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.Console()
        .CreateLogger();*//*

        private readonly ETourContext _context;

        public BookController(ETourContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Book_Kar(Book book)
        {
            double amt = 0;
            double tax = 0.50;
            double totalAmount = 0;
            double taxAmount = 0;
            if (_context.BookingHeader == null && _context.Passengers== null)
            {
                return Problem("Entity set 'ETourContext.BookingHeader' 'ETourContext.Passengers'  is null.");
            }
            else
            {

                if (book == null)
                {
                    return Problem("Empty Object Passed");
                }
               if(book.Passenger!=null)
                {
                    foreach (var passenger in book.Passenger)
                    {
                        amt +=  passenger.PassengerCost;

                    }
                }
                if(_context.BookingHeader!=null)
                {
                    book.Booking_Header.TourAmount = amt;
                    book.Booking_Header.Taxes = tax;
                    taxAmount = amt*tax;
                    totalAmount = amt+taxAmount;
                    book.Booking_Header.TotalAmount = totalAmount;

                    _context.BookingHeader.Add(book.Booking_Header);
                    *//* _context.Passengers.Add();*//*
                    await _context.SaveChangesAsync();
                }

                var query =  _context.BookingHeader.OrderByDescending(booking => booking.BookingId).FirstOrDefault();
                var bookingId = query.BookingId;
                //logger.LogDebug(bookingId);
               if(book.Passenger!=null)
                {
                    foreach (var passenger in book.Passenger)
                    {
                        passenger.BookingId = bookingId;
                        _context.Passengers.Add(passenger);
                        await _context.SaveChangesAsync();

                    }
                }


                return Ok(book);
            }


            *//*return CreatedAtAction("GetBooking_Header", new { id = booking_Header.BookingId }, booking_Header);*//*
            return Ok("Hi there");
        }

    }

    public class Book   
    {
        public Booking_Header? Booking_Header { get; set; }

        public List<Passenger_Master>? Passenger { get; set; }

    }

}
*//*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using EtourBeta.Model;
using EtourBackFinal.Model;


namespace EtourBeta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ETourContext _context;

        public BookingController(ETourContext context)
        {
            _context = context;
        }
        // POST: api/Booking
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookRequest>> PostBooking_Header_Table(BookRequest book)
        {
            double amt = 0;
            const double _tax = 0.18;
            double total = 0.50;
            double taxAmount = 0;

            if (_context.BookingHeader == null  && _context.Passengers==null)
            {
                return Problem("Entity set 'EtourContext.Booking_Header_Tables'  is null.");
            }
            if (book == null)
                return Problem("Empty Object Passed");
            if (book.Passenger!=null)
            {
                foreach (var p in book.Passenger)
                {
                    amt += p.PassengerCost;
                }
            }
            if (_context.BookingHeader!=null)
            {
                book.Booking.TourAmount = amt;
                taxAmount=  amt * _tax;
                book.Booking.Taxes = taxAmount;
                total = amt + taxAmount;
                book.Booking.TourAmount= total;

                _context.BookingHeader.Add(book.Booking);
                await _context.SaveChangesAsync();

            }


            *//*book.Booking.Tour_Amount = amt;
            book.Booking.Taxes = amt * _tax;
            book.Booking.Total_Amount = amt + (book.Booking.Taxes);*//*

            var latestBooking = _context.BookingHeader.OrderByDescending(b => b.BookingId).FirstOrDefault();

            var bookingId = latestBooking.BookingId;

            if (book.Passenger != null)
            {
                foreach (var p in book.Passenger)
                {
                    p.BookingId = bookingId;
                    _context.Passengers.Add(p);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(book);
        }



        private bool Booking_Header_TableExists(int id)
        {
            return (_context.BookingHeader?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }

    public class BookRequest
    {
        public Booking_Header? Booking { get; set; }
        public ICollection<Passenger_Master> Passenger { get; set; }
    }

}
*/
using EtourBackFinal.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EtourBackFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /* private ILogger logger = new LoggerConfiguration()
         .MinimumLevel.Debug()
         .WriteTo.Console()
         .CreateLogger();*/

        private readonly ETourContext _context;

        public BookController(ETourContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Book_Kar(Book book)
        {
            double amt = 0;
            double tax = 0.50;
            double totalAmount = 0;
            double taxAmount = 0;
            if (_context.BookingHeader == null && _context.Passengers== null)
            {
                return Problem("Entity set 'ETourContext.BookingHeader' 'ETourContext.Passengers'  is null.");
            }
            else
            {

                if (book == null)
                {
                    return Problem("Empty Object Passed");
                }
                if (book.Passenger!=null)
                {
                    foreach (var passenger in book.Passenger)
                    {
                        amt +=  passenger.PassengerCost;

                    }
                }
                if (book.Booking_Header!=null)
                {
                    book.Booking_Header.TourAmount = amt;
                    book.Booking_Header.Taxes = tax;
                    taxAmount = amt*tax;
                    totalAmount = amt+taxAmount;
                    book.Booking_Header.TotalAmount = totalAmount;

                    _context.BookingHeader.Add(book.Booking_Header);
                    /* _context.Passengers.Add();*/
                    await _context.SaveChangesAsync();
                }

                var query = _context.BookingHeader.OrderByDescending(booking => booking.BookingId).FirstOrDefault();
                var bookingId = query.BookingId;
                //logger.LogDebug(bookingId);
                if (book.Passenger!=null)
                {
                    foreach (var passenger in book.Passenger)
                    {
                        passenger.BookingId = bookingId;
                        _context.Passengers.Add(passenger);
                        await _context.SaveChangesAsync();

                    }
                }


                return Ok("done");
            }


            /*return CreatedAtAction("GetBooking_Header", new { id = booking_Header.BookingId }, booking_Header);*/
            return Ok("Hi there");
        }

    }

    public class Book
    {
        public Booking_Header? Booking_Header { get; set; }

        public List<Passenger_Master>? Passenger { get; set; }

    }

}