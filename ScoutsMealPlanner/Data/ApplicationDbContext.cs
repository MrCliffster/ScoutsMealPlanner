using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using ScoutsMealPlanner.Models;

namespace ScoutsMealPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Camps
            var straddy = new Camp { ID = Guid.NewGuid(), Name = "Stradbroke Cup" };
            var annual = new Camp { ID = Guid.NewGuid(), Name = "Annual Camp" };

            builder.Entity<Camp>().HasData(new List<Camp> { straddy, annual });

            // Equipment
            var pot = new Equipment { ID = Guid.NewGuid(), Name = "Pot (Large)" };

            builder.Entity<Equipment>().HasData(new List<Equipment> { pot });

            // Ingredient Categories
            var dairy = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Dairy" };
            var pantry = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Pantry" };
            var bakery = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Bakery" };
            var meat = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Meat" };
            var fresh = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Fresh" };

            builder.Entity<IngredientCategory>().HasData(new List<IngredientCategory> { dairy, pantry, bakery, meat, fresh });

            // Recipes
            var hotC = new Recipe { ID = Guid.NewGuid(), Name = "Hot Chocolate" };
            var hotD = new Recipe { ID = Guid.NewGuid(), Name = "Hot Dogs" };

            builder.Entity<Recipe>().HasData(new List<Recipe> { hotC, hotD });

            // Menus
            var peckers = new Menu { ID = Guid.NewGuid(), CampID = straddy.ID, MenuName = "Peckers Patrol Menu", StartDate = new DateTime(2020, 3, 18), EndDate = new DateTime(2020, 3, 20) };

            builder.Entity<Menu>().HasData(new List<Menu> { peckers });

            // Meals
            builder.Entity<Meal>().HasData(new List<Meal>
            {
                new Meal{ID = 1, Day = DayOfWeek.Friday, MealType = MealType.Supper, MenuID = 1},
                new Meal{ID = 2, Day = DayOfWeek.Saturday, MealType = MealType.Lunch, MenuID = 2}
            });

            // Ingredients
            builder.Entity<Ingredient>().HasData(new List<Ingredient>
            {
                new Ingredient{ID = 1, Name = "Milk - Full Cream (UHT)", IngredientCategoryID = 1, Unit ="Litre", UnitQuantity = 2, Perishable = true, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = false, UnitCost = 2.00},
                new Ingredient{ID = 2, Name = "Milk - Lactose Free (UHT) (LF)", IngredientCategoryID = 1, Unit ="Litre", UnitQuantity = 2, Perishable = false, Standard = false, Vegetarian = false, GlutenFree = false, LactoseFree = true, UnitCost = 2.00},
                new Ingredient{ID = 3, Name = "Hot Chocolate Powder", IngredientCategoryID = 2, Unit ="Kilogram", UnitQuantity = 0.4, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.00},
                new Ingredient{ID = 4, Name = "Sausages", IngredientCategoryID = 4, Unit ="Each", UnitQuantity = 1, Perishable = true, Standard = true, Vegetarian = false, GlutenFree = true, LactoseFree = true, UnitCost = 1.16},
                new Ingredient{ID = 5, Name = "Vegetarian Sausages", IngredientCategoryID = 2, Unit ="Packet", UnitQuantity = 0.33, Perishable = true, Standard = false, Vegetarian = true, GlutenFree = false, LactoseFree = false, UnitCost = 6.00},
                new Ingredient{ID = 6, Name = "Hot Dog Buns", IngredientCategoryID = 3, Unit ="Each", UnitQuantity = 1, Perishable = true, Standard = true, Vegetarian = true, GlutenFree = false, LactoseFree = true, UnitCost = 2.00},
                new Ingredient{ID = 7, Name = "Gluten Free Bread (GF)", IngredientCategoryID = 3, Unit ="Loaf", UnitQuantity = 1, Perishable = false, Standard = false, Vegetarian = false, GlutenFree = true, LactoseFree = false, UnitCost = 7.00},
                new Ingredient{ID = 8, Name = "Tomato Sauce", IngredientCategoryID =2, Unit ="Bottle", UnitQuantity = 1, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.00},
                new Ingredient{ID = 9, Name = "Mustard", IngredientCategoryID = 2, Unit ="Bottle", UnitQuantity = 1, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.15},
                new Ingredient{ID = 10, Name = "BBQ Sauce", IngredientCategoryID = 2, Unit ="Bottle", UnitQuantity = 1, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.00}
            });

            // Ingredient Entries
            builder.Entity<IngredientEntry>().HasData(new List<IngredientEntry>
            {
                new IngredientEntry{IngredientID = 1, RecipeID = 1, QuantityNeeded = 0.20},
                new IngredientEntry{IngredientID = 2, RecipeID = 1, QuantityNeeded = 0.20},
                new IngredientEntry{IngredientID = 3, RecipeID = 1, QuantityNeeded = 0.045},
                new IngredientEntry{IngredientID = 4, RecipeID = 2, QuantityNeeded = 1.75},
                new IngredientEntry{IngredientID = 5, RecipeID = 2, QuantityNeeded = 1.75},
                new IngredientEntry{IngredientID = 6, RecipeID = 2, QuantityNeeded = 2},
                new IngredientEntry{IngredientID = 7, RecipeID = 2, QuantityNeeded = 0.1},
                new IngredientEntry{IngredientID = 8, RecipeID = 2, QuantityNeeded = 0.02},
                new IngredientEntry{IngredientID = 9, RecipeID = 2, QuantityNeeded = 0.01},
                new IngredientEntry{IngredientID = 10, RecipeID = 2, QuantityNeeded = 0.01},
            });

            // Meal Recipes
            builder.Entity<MealRecipe>().HasData(new List<MealRecipe>
            {
                new MealRecipe {MealID = 1, RecipeID = 1},
                new MealRecipe {MealID = 2, RecipeID = 2}
            });

            // Recipe Equipments
            builder.Entity<RecipeEquipment>().HasData(new List<RecipeEquipment>
            {
                new RecipeEquipment{RecipeID = 1, EquipmentID = 1}
            });
        }
    }
}
