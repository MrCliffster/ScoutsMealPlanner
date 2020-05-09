using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ScoutsMealPlanner.Models
{
    public enum MealType
    {
        Breakfast,
        Lunch,
        Dinner,
        Snack,
        Supper,
        General
    }

    public class Meal
    {
        public Guid ID { get; set; }
        public Guid MenuID { get; set; }
        [Required]
        [Display(Name = "Meal Type")]
        public MealType MealType { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }

        public Menu Menu { get; set; }
        public ICollection<MealRecipe> MealRecipes { get; set; }
    }
}
