using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExploreCalifornia.Models;
namespace ExploreCalifornia.Controllers
{
    public class TourController : Controller
    {
        static Tour tour1 = new Tour
        {
            Name = "Cali Walking Tour"
        };

        static Tour tour2 = new Tour
        {
            Name = "Cali Cycling Tour"
        };

        static List<Tour> model = new List<Tour>{tour1, tour2 };

        // GET: Tour
        public ActionResult Index()
        {     
            return View(model);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            var tour = model.Where(t => t.Id == id).FirstOrDefault();
            return View("View", tour);
        }

        // GET: Tour/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tour/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int id =  Convert.ToInt32(collection["id"]);
                Tour tour = new Tour
                {
                    Id = id,
                    Name = collection["Name"],
                    Description = collection["Description"],
                    Length = Convert.ToInt32(collection["Length"]),
                    Price = Convert.ToDecimal(collection["Price"]),
                    Rating = collection["Rating"],
                    IncludesMeals = Convert.ToBoolean(collection["IncludesMeals"])
                };
                model.Add(tour);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Details), new {Id = id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            var tour = model.Where(t => t.Id == id).FirstOrDefault();
            return View(tour);
        }

        // POST: Tour/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Tour/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}