using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Entities;
using RecipeBook.Services;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : Controller
    {
        private IRecipeBookService _recipeBookService;
        public IngredientsController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }

        [HttpGet(Name ="GetIngredients")]
        public IActionResult GetIngredients()
        {
            var ingredients = _recipeBookService.GetIngredients();
            return Ok(ingredients);
        }

        [HttpGet("{id}")]
        public IActionResult GetIngredient(int id)
        {
            var ingredient = _recipeBookService.GetIngredient(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        //FromBody means that the parameter needs to be deserielized.
        [HttpPost]
        public IActionResult CreateIngredient([FromBody]Ingredient ingredient)
        {
            if (ingredient == null)
            {
                return BadRequest();
            }

            _recipeBookService.AddIngredient(ingredient);
            if (!_recipeBookService.Save())
            {
                throw new Exception("Not saved!");
            }

            return CreatedAtRoute("GetIngredients", ingredient);
        }

    }
}