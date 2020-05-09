using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace ScoutsMealPlanner.Models
{
    public class Recipe
    {
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<RecipeEquipment> RecipeEquipments { get; set; }
        public ICollection<IngredientEntry> IngredientEntries { get; set; }
        public ICollection<MealRecipe> MealRecipes { get; set; }
    }
}
