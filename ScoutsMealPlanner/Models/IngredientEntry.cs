using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Models
{
    public class IngredientEntry
    {
        public Guid IngredientID { get; set; }
        public Guid RecipeID { get; set; }
        [Display(Name = "Quantity Needed")]
        public double QuantityNeeded { get; set; }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
    }
}
