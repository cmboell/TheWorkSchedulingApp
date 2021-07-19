using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TheWorkSchedulingApp.Models;
namespace TheWorkSchedulingApp.Controllers
{
    public class PositionController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private IWorkScheduleUnitOfWork data { get; set; }

        public PositionController(IWorkScheduleUnitOfWork rep, IHttpContextAccessor ctx)
        {
            data = rep;
            http = ctx;
        }

        public RedirectToActionResult Index()
        {
            // clear session and navigate to list of classes
            http.HttpContext.Session.Remove("dayid");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var p = this.GetPosition(id);
            return View("Add", p);
        }
    
        [HttpPost]
        public IActionResult Add(Position p)
        {
            string operation = (p.PositionId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (p.PositionId == 0)
                    data.Positions.Insert(p);
                else
                    data.Positions.Update(p);
                data.Positions.Save();

                string verb = (operation == "Add") ? "added" : "updated";
                TempData["msg"] = $"{p.PositionName} {verb}";

                return this.GoToPositions();
            }
            else
            {
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var p = this.GetPosition(id);
            ViewBag.DayId = http.HttpContext.Session.GetInt32("dayid");
            return View(p);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Position p)
        {
            p = data.Positions.Get(p.PositionId); // so can get class title for notification message

            data.Positions.Delete(p);
            data.Positions.Save();

            TempData["msg"] = $"{p.PositionName} deleted";

            return this.GoToPositions();
        }

        // private helper methods
        private Position GetPosition(int id)
        {
            var classOptions = new QueryOptions<Position>
            {
                Includes = "Worker, Day",
                Where = w => w.PositionId == id
            };
            return data.Positions.Get(classOptions);
        }

        private void LoadViewBag(string operation)
        {
            ViewBag.Days = data.Days.List(new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            });
            ViewBag.Workers = data.Workers.List(new QueryOptions<Worker>
            {
                OrderBy = w => w.LastName
            });

            ViewBag.Operation = operation;
            ViewBag.DayId = http.HttpContext.Session.GetInt32("dayid");
        }

        private RedirectToActionResult GoToPositions()
        {
            // if session has a value for day id, add to id route segment when redirecting
            if (http.HttpContext.Session.GetInt32("dayid").HasValue)
                return RedirectToAction("Index", "Home", new { id = http.HttpContext.Session.GetInt32("dayid") });
            else
                return RedirectToAction("Index", "Home");
        }
    }
}