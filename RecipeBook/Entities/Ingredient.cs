﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Entities
{
    public class Ingredient
    {
        public int Id{ get; set; }

        public string Name { get; set; }

        public int Calories { get; set; }

        //the amount to the calories 
        public decimal Amount { get; set; }
    }
}
