using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TheWorkSchedulingApp.Models;
namespace TheWorkSchedulingApp.Controllers
{

    public class HomeController : Controller
    {
        private IHttpContextAccessor http { get; set; }
        private IWorkScheduleUnitOfWork data { get; set; }

        public HomeController(IWorkScheduleUnitOfWork unit, IHttpContextAccessor ctx)
        {
            data = unit;
            http = ctx;
        }

        public ViewResult Index(int id)
        {
            // if day id passed to action method, store in session
            if (id > 0)
            {
                http.HttpContext.Session.SetInt32("dayid", id);
            }

            // options for Days query
            var dayOptions = new QueryOptions<Day>
            {
                OrderBy = d => d.DayId
            };

            // options for Positions query
            var positionOptions = new QueryOptions<Position>
            {
                Includes = "Worker, Day"
            };

            // order by day if no day id. Otherwise, filter by day and order by time.
            if (id == 0)
            {
                positionOptions.OrderBy = p => p.DayId;
            }
            else
            {
                positionOptions.Where = p => p.DayId == id;
                positionOptions.OrderBy = p => p.MilitaryTime;
            }

            // execute queries
            ViewBag.Days = data.Days.List(dayOptions);
            return View(data.Positions.List(positionOptions));
        }
    }
}
