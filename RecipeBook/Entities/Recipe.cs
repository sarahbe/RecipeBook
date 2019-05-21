using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string RecipeName { get; set; }
        public int CategoryId { get; set; }
        public bool Valid { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Step> Steps { get; set; } = new List<Step>();
        public ICollection<RecipeDetail> RecipeDetail { get; set; } = new List<RecipeDetail>();
    }
}
