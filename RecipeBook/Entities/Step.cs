using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Entities
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
