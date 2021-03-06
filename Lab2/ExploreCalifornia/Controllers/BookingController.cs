﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExploreCalifornia.Controllers
{
    public class BookingController : Controller
    {
        static List<Booking> bookingList = new List<Booking>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(bookingList);
        }

        public ActionResult Create()
        {
            return View();
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            var booking = bookingList.Where(t => t.Id == id).FirstOrDefault();
            return View(booking);
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            var booking = bookingList.Where(t => t.Id == id).FirstOrDefault();
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Random random = new Random();
            try
            {
                int id = random.Next();
                Booking book = new Booking
                {
                    Id = id,
                    TourID = Convert.ToInt32(collection["TourID"]),
                    TourName = collection["TourName"],
                    ClientID = Convert.ToInt32(collection["ClientID"]),
                    DepartureDate = Convert.ToDateTime(collection["DepartureDate"]),
                    NumberOfPeople = Convert.ToInt32(collection["NumberOfPeople"]),
                    FullName = collection["FullName"],
                    Email = collection["Email"],
                    ContactNo = Convert.ToInt32(collection["contactNo"]),
                    SpecialRequest = collection["SpecialRequest"]
                };
                bookingList.Add(book);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Details), new
                {
                    Id = id
                });
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var booking = bookingList.Where(t => t.Id == id).FirstOrDefault();
                booking.TourID = Convert.ToInt32(collection["TourID"]);
                booking.TourName = collection["TourName"];
                booking.ClientID = Convert.ToInt32(collection["ClientID"]);
                booking.DepartureDate = Convert.ToDateTime(collection["DepartureDate"]);
                booking.NumberOfPeople = Convert.ToInt32(collection["NumberOfPeople"]);
                booking.FullName = collection["FullName"];
                booking.Email = collection["Email"];
                booking.ContactNo = Convert.ToInt32(collection["contactNo"]);
                booking.SpecialRequest = collection["SpecialRequest"];
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Tour/Delete/5
        public ActionResult Delete(int id)
        {
            var booking = bookingList.Where(t => t.Id == id).FirstOrDefault();
            if (booking != null)
            {
                bookingList.Remove(booking);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
