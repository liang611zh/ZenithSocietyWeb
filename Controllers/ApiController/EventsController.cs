using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithWebSite.Data;
using ZenithWebSite.Models;
using Microsoft.AspNetCore.Cors;

namespace ZenithWebSite.Controllers.ApiController
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public IEnumerable<Event> GetEvents()
        {
            return _context.Events;
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }


        // GET: api/Events/Week/0
        [HttpGet("Week/{week}")]
        public IActionResult GetEventsByWeek([FromRoute] int week)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //get today date
            var today = DateTime.Today;
            //check today differ with monday
            int days = today.DayOfWeek - DayOfWeek.Monday;
            if (days < 0)
            {
                days += 7;
            }
            var monday = today.AddDays(-days).Date;          
            var weekstart = monday.AddDays(7 * week); ;
            var weekend = weekstart.AddDays(7);
            var @event =  _context.Events
                .Include(m => m.Activity)
                .Where(m => m.EventFrom >= monday && m.EventTo < weekend)
                .OrderBy(m => m.EventFrom)
                .Select(m=>new EventWeek(m));
            if (@event == null)
            {
                return NotFound();
            }
            return Ok(@event);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        [HttpPost]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}