using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ScoutsMealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Camps
            var straddy = new Camp { ID = Guid.NewGuid(), Name = "Stradbroke Cup" };
            var annual = new Camp { ID = Guid.NewGuid(), Name = "Annual Camp" };

            modelBuilder.Entity<Camp>().HasData(new List<Camp> { straddy, annual });

            // Equipment
            var pot = new Equipment { ID = Guid.NewGuid(), Name = "Pot (Large)" };

            modelBuilder.Entity<Equipment>().HasData(new List<Equipment> { pot });

            // Ingredient Categories
            var dairy = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Dairy" };
            var pantry = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Pantry" };
            var bakery = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Bakery" };
            var meat = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Meat" };
            var fresh = new IngredientCategory { IngredientCategoryID = Guid.NewGuid(), Name = "Fresh" };

            modelBuilder.Entity<IngredientCategory>().HasData(new List<IngredientCategory> { dairy, pantry, bakery, meat, fresh });

            // Recipes
            var hotC = new Recipe { ID = Guid.NewGuid(), Name = "Hot Chocolate" };
            var hotD = new Recipe { ID = Guid.NewGuid(), Name = "Hot Dogs" };

            modelBuilder.Entity<Recipe>().HasData(new List<Recipe> { hotC, hotD });

            // Menus
            var peckers = new Menu { ID = Guid.NewGuid(), CampID = straddy.ID, MenuName = "Peckers Patrol Menu", StartDate = new DateTime(2020, 3, 18), EndDate = new DateTime(2020, 3, 20) };

            modelBuilder.Entity<Menu>().HasData(new List<Menu> { peckers });

            // Meals
            var friSup = new Meal { ID = Guid.NewGuid(), Day = DayOfWeek.Friday, MealType = MealType.Supper, MenuID = peckers.ID };
            var satLunch = new Meal { ID = Guid.NewGuid(), Day = DayOfWeek.Saturday, MealType = MealType.Lunch, MenuID = peckers.ID };

            modelBuilder.Entity<Meal>().HasData(new List<Meal> { friSup, satLunch });

            // Ingredients
            var fcMilk = new Ingredient { ID = Guid.NewGuid(), Name = "Milk - Full Cream (UHT)", IngredientCategoryID = dairy.IngredientCategoryID, Unit = "Litre", UnitQuantity = 2, Perishable = true, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = false, UnitCost = 2.00 };
            var lfMilk = new Ingredient { ID = Guid.NewGuid(), Name = "Milk - Lactose Free (UHT) (LF)", IngredientCategoryID = dairy.IngredientCategoryID, Unit = "Litre", UnitQuantity = 2, Perishable = false, Standard = false, Vegetarian = false, GlutenFree = false, LactoseFree = true, UnitCost = 2.00 };
            var hcPowder = new Ingredient { ID = Guid.NewGuid(), Name = "Hot Chocolate Powder", IngredientCategoryID = pantry.IngredientCategoryID, Unit = "Kilogram", UnitQuantity = 0.4, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.00 };
            var snags = new Ingredient { ID = Guid.NewGuid(), Name = "Sausages", IngredientCategoryID = meat.IngredientCategoryID, Unit = "Each", UnitQuantity = 1, Perishable = true, Standard = true, Vegetarian = false, GlutenFree = true, LactoseFree = true, UnitCost = 1.16 };
            var veggieSnags = new Ingredient { ID = Guid.NewGuid(), Name = "Vegetarian Sausages", IngredientCategoryID = pantry.IngredientCategoryID, Unit = "Packet", UnitQuantity = 0.33, Perishable = true, Standard = false, Vegetarian = true, GlutenFree = false, LactoseFree = false, UnitCost = 6.00 };
            var hotDogBuns = new Ingredient { ID = Guid.NewGuid(), Name = "Hot Dog Buns", IngredientCategoryID = bakery.IngredientCategoryID, Unit = "Each", UnitQuantity = 1, Perishable = true, Standard = true, Vegetarian = true, GlutenFree = false, LactoseFree = true, UnitCost = 2.00 };
            var gfBread = new Ingredient { ID = Guid.NewGuid(), Name = "Gluten Free Bread (GF)", IngredientCategoryID = bakery.IngredientCategoryID, Unit = "Loaf", UnitQuantity = 1, Perishable = false, Standard = false, Vegetarian = false, GlutenFree = true, LactoseFree = false, UnitCost = 7.00 };
            var tomatoSauce = new Ingredient { ID = Guid.NewGuid(), Name = "Tomato Sauce", IngredientCategoryID = pantry.IngredientCategoryID, Unit = "Bottle", UnitQuantity = 1, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.00 };
            var mustard = new Ingredient { ID = Guid.NewGuid(), Name = "Mustard", IngredientCategoryID = pantry.IngredientCategoryID, Unit = "Bottle", UnitQuantity = 1, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.15 };
            var bbq = new Ingredient { ID = Guid.NewGuid(), Name = "BBQ Sauce", IngredientCategoryID = pantry.IngredientCategoryID, Unit = "Bottle", UnitQuantity = 1, Perishable = false, Standard = true, Vegetarian = true, GlutenFree = true, LactoseFree = true, UnitCost = 4.00 };

            modelBuilder.Entity<Ingredient>().HasData(new List<Ingredient> { fcMilk, lfMilk, hcPowder, snags, veggieSnags, hotDogBuns, gfBread, tomatoSauce, mustard, bbq });

            // Ingredient Entries
            modelBuilder.Entity<IngredientEntry>().HasData(new List<IngredientEntry>
            {
                new IngredientEntry{IngredientID = fcMilk.ID, RecipeID = hotC.ID, QuantityNeeded = 0.20},
                new IngredientEntry{IngredientID = lfMilk.ID, RecipeID = hotC.ID, QuantityNeeded = 0.20},
                new IngredientEntry{IngredientID = hcPowder.ID, RecipeID = hotC.ID, QuantityNeeded = 0.045},
                new IngredientEntry{IngredientID = snags.ID, RecipeID = hotD.ID, QuantityNeeded = 1.75},
                new IngredientEntry{IngredientID = veggieSnags.ID, RecipeID = hotD.ID, QuantityNeeded = 1.75},
                new IngredientEntry{IngredientID = hotDogBuns.ID, RecipeID = hotD.ID, QuantityNeeded = 2},
                new IngredientEntry{IngredientID = gfBread.ID, RecipeID = hotD.ID, QuantityNeeded = 0.1},
                new IngredientEntry{IngredientID = tomatoSauce.ID, RecipeID = hotD.ID, QuantityNeeded = 0.02},
                new IngredientEntry{IngredientID = mustard.ID, RecipeID = hotD.ID, QuantityNeeded = 0.01},
                new IngredientEntry{IngredientID = bbq.ID, RecipeID = hotD.ID, QuantityNeeded = 0.01},
            });

            // Meal Recipes
            modelBuilder.Entity<MealRecipe>().HasData(new List<MealRecipe>
            {
                new MealRecipe {MealID = friSup.ID, RecipeID = hotC.ID},
                new MealRecipe {MealID = satLunch.ID, RecipeID = hotD.ID}
            });

            // Recipe Equipments
            modelBuilder.Entity<RecipeEquipment>().HasData(new List<RecipeEquipment>
            {
                new RecipeEquipment{RecipeID = hotC.ID, EquipmentID = pot.ID}
            });
        }
    }
}
