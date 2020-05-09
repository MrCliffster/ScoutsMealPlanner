using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Models
{
    public class IngredientCategory
    {
        public Guid IngredientCategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
