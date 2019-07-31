using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Entities
{
    /// <summary>
    /// The details of ingredients and amounts 
    /// </summary>
    public class RecipeDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }
        
        public int Sequence { get; set; }

        [Required]
        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public Recipe Recipe { get; set; }
    }
}
