using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Entities
{
    public class Ingredient
    {
        public int Id{ get; set; }

        [Required]
        public string Name { get; set; }

        public int Calories { get; set; }

        //the amount to the calories 
        [Required]
        public decimal Amount { get; set; }
    }
}
