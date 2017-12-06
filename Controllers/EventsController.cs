using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ZenithWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EventsController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Events.Include(a => a.Activity);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(a => a.Activity)
                .SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDescription");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventFrom,EventTo,Username,ActivityId,CreationDate,IsActive")] Event @event)
        {
            if (ModelState.IsValid)
            {
                var User = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
                @event.Username = User?.UserName;
                if (@event.EventFrom < @event.EventTo)
                {
                    _context.Add(@event);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else if (@event.EventFrom >= @event.EventTo) {
                    ViewBag.TimeInvalid = "The end time should be later than start time.";
                    return RedirectToAction("Create");
                }
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventFrom,EventTo,Username,ActivityId,CreationDate,IsActive")] Event @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var User = await _signInManager.UserManager.GetUserAsync(HttpContext.User);
                    @event.Username = User?.UserName;
                    if (@event.EventFrom < @event.EventTo)
                    {
                        _context.Update(@event);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else if (@event.EventFrom >= @event.EventTo)
                    {
                        ViewBag.TimeInvalid = "The end time should be later than start time.";
                        return RedirectToAction("Create");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.EventId))
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
            ViewData["ActivityId"] = new SelectList(_context.Activities, "ActivityId", "ActivityDescription", @event.ActivityId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(a => a.Activity)
                .SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}
