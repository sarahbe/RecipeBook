using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Services;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IRecipeBookService _recipeBookService;
        public IngredientController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }

        [HttpGet]
        public IActionResult GetIngredients()
        {
            var ingredients = _recipeBookService.GetIngredients();
            return Ok(ingredients);
        }

        [HttpGet]
        public IActionResult GetIngredient(int id)
        {
            var ingredient = _recipeBookService.GetIngredient(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

    }
}