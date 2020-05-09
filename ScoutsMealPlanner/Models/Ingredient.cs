using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScoutsMealPlanner.Models
{
    public class Ingredient
    {
        public Guid ID { get; set; }

        // Foreign Keys
        public Guid IngredientCategoryID { get; set; }

        // Own fields
        public string Name { get; set; }
        public string Unit { get; set; }
        [Display(Name = "Unit Quantity")]
        public double UnitQuantity { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Unit Cost")]
        public double UnitCost { get; set; }
        public bool Perishable { get; set; }
        public bool Standard { get; set; }
        public bool Vegetarian { get; set; }
        [Display(Name = "Gluten Free")]
        public bool GlutenFree { get; set; }
        [Display(Name = "Lactose Free")]
        public bool LactoseFree { get; set; }

        // Navigation properties
        [Display(Name = "Ingredient Category")]
        public IngredientCategory IngredientCategory { get; set; }
        public ICollection<Ingredient> Substitutions { get; set; }
    }
}
