using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZenithWebSite.Models;
using ZenithWebSite.Data;
using Microsoft.EntityFrameworkCore;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DateTime mondayDate = DateTime
                          .Today
                          .AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 1);

            DateTime sundayDate = DateTime
                          .Today
                          .AddDays(((int)(DateTime.Today.DayOfWeek) * -1) + 8);

            var events = _context.Events.Include(e => e.Activity).ToList();
            events = events.OrderBy(e => e.EventFrom)
                .Where(e => e.EventFrom >= mondayDate && e.EventFrom <= sundayDate)
                .ToList();

            var eventsDetail = new Dictionary<string, List<Event>>();

            foreach (var i in events)
            {
                if (eventsDetail.ContainsKey(i.EventFrom.ToLongDateString()))
                {
                    eventsDetail[i.EventFrom.ToLongDateString()].Add(i);
                }
                else
                {
                    eventsDetail[i.EventFrom.ToLongDateString()] = new List<Event> { i };
                }
            }

            return View(eventsDetail);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
