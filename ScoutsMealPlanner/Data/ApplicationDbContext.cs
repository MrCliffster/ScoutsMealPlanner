using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using ScoutsMealPlanner.Data.Configurations;
using ScoutsMealPlanner.Models;

namespace ScoutsMealPlanner.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camp> Camps { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<IngredientCategory> IngredientCategories { get; set; }

        public DbSet<IngredientEntry> IngredientEntries { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealRecipe> MealRecipes { get; set; }
        
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeEquipment> RecipeEquipment { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelBuilderExtensions.Seed(builder);
            builder.ApplyConfiguration(new IngredientEntryConfiguration());
            builder.ApplyConfiguration(new MealRecipeConfiguration());
            builder.ApplyConfiguration(new RecipeEquipmentConfiguration());
        }
    }
}
