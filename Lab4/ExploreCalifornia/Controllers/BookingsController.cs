using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;
using ExploreCalifornia.Data;
using Microsoft.AspNetCore.Authorization;

namespace ExploreCalifornia.Controllers
{
    public class BookingsController : GeneralController<Booking>
    {
        private readonly ExploreCaliforniaContext _context;
        private BookingGateway bookingGateway;

        public BookingsController(ExploreCaliforniaContext context) : base(context)
        {
            _context = context;
            bookingGateway = new BookingGateway(context);
        }


        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public override IActionResult Create([Bind("Id,TourID,TourName,ClientID,DepartureDate,NumberOfPeople,FullName,Email,ContactNo,SpecialRequest")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                bookingGateway.Insert(booking);
                var newlyCreatedId = booking.Id;
                return RedirectToAction(nameof(Confirm), new {  id = newlyCreatedId});
            }
            return View(booking);
        }
    }
}
