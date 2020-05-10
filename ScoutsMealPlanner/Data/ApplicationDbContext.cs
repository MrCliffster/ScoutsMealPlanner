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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelBuilderExtensions.Seed(builder);
            builder.ApplyConfiguration(new IngredientEntryConfiguration());
        }
    }
}
