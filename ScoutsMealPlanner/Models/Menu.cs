using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoutsMealPlanner.Models
{
    public class Menu
    {
        public Guid ID { get; set; }
        
        // Foreign Keys
        public Guid CampID { get; set; }
        [Display(Name = "Name")]
        public string MenuName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [ForeignKey("CampID")]
        public Camp Camp { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
