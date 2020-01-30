using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExploreCalifornia.Models;
using ExploreCalifornia.Data;

namespace ExploreCalifornia.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourGateway tourGateway;

        public ToursController(ExploreCaliforniaContext context)
        {
            tourGateway = new TourGateway(context);
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {
            return View(await tourGateway.SelectAll());
        }

        // GET: Tours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await tourGateway.SelectById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                tour = tourGateway.Insert(tour);
                var newlyCreatedId = tour.Id;
                return RedirectToAction(nameof(Confirm), new { id = newlyCreatedId});
            }
            return View(tour);
        }

        // GET: Tours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await tourGateway.SelectById(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Length,Price,Rating,IncludesMeals")] Tour tour)
        {
            if (id != tour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tourGateway.Update(tour);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.Id))
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
            return View(tour);
        }

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await tourGateway.SelectById(id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tour = await tourGateway.SelectById(id);
            tour = tourGateway.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(int id)
        {
            return tourGateway.Exist(id);
        }

        public async Task<IActionResult> Confirm(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var tour = await tourGateway.SelectById(id);

            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }
    }
}
