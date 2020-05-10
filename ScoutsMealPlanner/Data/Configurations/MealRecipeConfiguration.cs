using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoutsMealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Data.Configurations
{
    public class MealRecipeConfiguration : IEntityTypeConfiguration<MealRecipe>
    {
        public void Configure(EntityTypeBuilder<MealRecipe> builder)
        {
            builder.HasKey(mr => new { mr.MealID, mr.RecipeID });
        }
    }
}
