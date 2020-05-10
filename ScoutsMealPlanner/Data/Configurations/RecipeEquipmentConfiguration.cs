using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScoutsMealPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoutsMealPlanner.Data.Configurations
{
    public class RecipeEquipmentConfiguration : IEntityTypeConfiguration<RecipeEquipment>
    {
        public void Configure(EntityTypeBuilder<RecipeEquipment> builder)
        {
            builder.HasKey(recipeEquip => new { recipeEquip.RecipeID, recipeEquip.EquipmentID });
        }
    }
}
