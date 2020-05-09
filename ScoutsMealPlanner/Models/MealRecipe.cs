using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Models
{
    public class MealRecipe
    {
        public Guid MealID { get; set; }
        public Guid RecipeID { get; set; }
        public Meal Meal { get; set; }
        public Recipe Recipe { get; set; }
    }
}
