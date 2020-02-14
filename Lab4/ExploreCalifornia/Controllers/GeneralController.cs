using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Data;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia.Controllers
{
    public class GeneralController<T> : Controller where T:class, new()
    {
        private DataGateway<T> dataGateway;
        internal ExploreCaliforniaContext db;

        public GeneralController(ExploreCaliforniaContext context)
        {
            db = context;
            dataGateway = new DataGateway<T>(context);
        }
        [Authorize]
        public virtual IActionResult Create(int tourId, string tourName)
        {
            ViewBag.TourID = tourId;
            ViewBag.ClientID = User.Identity.Name;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Create(T t)
        {
            if (ModelState.IsValid)
            {
                dataGateway.Insert(t);
            }
            return View(t);
        }

        public virtual IActionResult Index(int? value)
        {
            var data = dataGateway.SelectAll();
            return View(data);
        }

        public virtual IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectDetails = dataGateway.SelectById(id);
            if (objectDetails == null)
            {
                return NotFound();
            }

            return View(objectDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(int id, T t)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dataGateway.Update(t);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(t);
        }

        public virtual IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var booking = await _context.Booking.FindAsync(id);
            var objectDetails = dataGateway.SelectById(id);
            if (objectDetails == null)
            {
                return NotFound();
            }
            return View(objectDetails);
        }
      
        public virtual IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectDetails = dataGateway.SelectById(id);
            if (objectDetails == null)
            {
                return NotFound();
            }

            return View(objectDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirmed(int id)
        {
            //var booking = await _context.Booking.FindAsync(id);
            //_context.Booking.Remove(booking);
            //await _context.SaveChangesAsync();
            var booking = dataGateway.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public virtual bool ObjectExists(int id)
        {
            if (dataGateway.SelectById(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectDetails = dataGateway.SelectById(id);
            if (objectDetails == null)
            {
                return NotFound();
            }

            return View(objectDetails);
        }

    }
}