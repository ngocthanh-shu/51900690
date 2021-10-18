using Lab3_51900690.Models;
using Lab3_51900690.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3_51900690.Controllers
{
    public class LaptopController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            var lstLaptop = LaptopRes.GetAll();
            return View(lstLaptop);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(string ID)
        {
            if(ID == null)
            {
                return NotFound();
            }
            var laptop = LaptopRes.GetByID(ID);
            if(laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            var laptop = new Laptop();
            return View(laptop);
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                laptop = LaptopRes.InsertLaptop(laptop);
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(string id)
        {
            if(id == null)
                return NotFound();
            var laptop = LaptopRes.GetByID(id);
            if(laptop == null)
                return NotFound();
            return View(laptop);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Laptop laptop)
        {
            if (id != laptop.ID)
                return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    laptop = LaptopRes.EditByIDs(laptop);
                }
                catch (Exception e)
                {
                    if (!LaptopExists(laptop.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(laptop);
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
                return NotFound();
            var laptop = LaptopRes.GetByID(id);
            if (laptop == null)
                return NotFound();
            return View(laptop);
        }

        // POST: HomeController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var laptop = LaptopRes.DeleteByID(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LaptopExists(string id)
        {
            return false;
        }
    }
}
