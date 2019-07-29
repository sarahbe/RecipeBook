using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public String RecipeName { get; set; }
        public String CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
