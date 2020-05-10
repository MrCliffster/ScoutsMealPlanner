using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoutsMealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Data.Configurations
{
    public class IngredientEntryConfiguration : IEntityTypeConfiguration<IngredientEntry>
    {
        public void Configure(EntityTypeBuilder<IngredientEntry> builder)
        {
            builder.HasKey(ingEntry => new { ingEntry.IngredientID, ingEntry.RecipeID });
        }
    }
}
