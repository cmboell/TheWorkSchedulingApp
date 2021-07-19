using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheWorkSchedulingApp.Models;

namespace TheWorkSchedulingApp.Controllers
{
    public class WorkerController : Controller
    {
        private IRepository<Worker> workers { get; set; }
        public WorkerController(IRepository<Worker> rep) => workers = rep;

        public ViewResult Index()
        {
            var options = new QueryOptions<Worker>
            {
                OrderBy = w => w.LastName
            };
            return View(workers.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Worker worker)
        {
            if (ModelState.IsValid)
            {
                workers.Insert(worker);
                workers.Save();

                TempData["msg"] = $"{worker.FullName} added to list of workers";

                return RedirectToAction("Index");
            }
            else
            {
                return View(worker);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(workers.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Worker worker)
        {
            worker = workers.Get(worker.WorkerId); // so can get worker name for notification message

            workers.Delete(worker);
            workers.Save();

            TempData["msg"] = $"{worker.FullName} removed from list of workers";

            return RedirectToAction("Index");
        }
    }
}
