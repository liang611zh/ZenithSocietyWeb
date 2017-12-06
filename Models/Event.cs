using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebSite.Models
{
    public class Event
    {

        [Key]
        public int EventId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please enter correct format")]
        [Display(Name = "Event Start Time")]
        public DateTime EventFrom { get; set; }

        [Required(ErrorMessage = "Please enter correct format")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Event End Time")]
        public DateTime EventTo { get; set; }


        private string _CreatedByUser = "";
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Created By")]
        public string Username { get { return _CreatedByUser; } set { _CreatedByUser = value; } }

        [Display(Name = "Activity"), Required]
        public int ActivityId { get; set; }

        [Display(Name = "Activity")]
        public Activity Activity { get; set; }

        private DateTime _CreationDate = DateTime.Now;
        [DataType(DataType.DateTime)]
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get { return _CreationDate; } set { _CreationDate = value; } }

        [Display(Name = "Is Active"), Required]
        public bool IsActive { get; set; }
    }
}
