using Microsoft.EntityFrameworkCore;
using RecipeBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.DataLayer
{
    public class RecipeBookContext :DbContext 
    {
        public RecipeBookContext(DbContextOptions<RecipeBookContext> options)
          : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
    }
}
