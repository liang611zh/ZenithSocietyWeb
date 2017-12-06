using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebSite.Models
{
    public class EventWeek
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ActivityDescription { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreationDate{ get; set; }

        public EventWeek(Event e)
        {
            EventId = e.EventId;
            EventDate = e.EventFrom.Date;
            StartTime = e.EventTo.TimeOfDay;
            EndTime = e.EventTo.TimeOfDay;

            if (e.Activity != null)
            {
                ActivityId = e.ActivityId;
                ActivityDescription = e.Activity.ActivityDescription;
                CreationDate = e.CreationDate;
            }
        }
    }
}
