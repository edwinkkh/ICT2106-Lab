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
        // GET: Tour
        public ActionResult Index()
        {
            Tour tour1 = new Tour();
            tour1.Name = "Cali Walking Tour";

            Tour tour2 = new Tour();
            tour2.Name = "Cali Cycling Tour";

            var model = new List<Tour> { tour1, tour2 };
            return View(model);
        }

        // GET: Tour/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Tour/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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