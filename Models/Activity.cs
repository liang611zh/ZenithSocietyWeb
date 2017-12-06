using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebSite.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [Display(Name = "Activity Description"), Required]
        public string ActivityDescription { get; set; }

        private DateTime _CreationDate = DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        [HiddenInput(DisplayValue = true)]
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set { _CreationDate = value; }
        }

        public List<Event> Events { get; set; }
    }
}
