using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Entities;
using RecipeBook.Services;

namespace RecipeBook.Controllers
{
    [Route("api/recipe/{recipeId}/recipeDetails")]
    public class RecipeDetailsController : Controller
    {
        private IRecipeBookService _recipeBookService;
        public RecipeDetailsController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }
        [HttpGet(Name ="GetDetails")]
        public IActionResult GetRecipeDetails(int recipeId)
        {
            var receipeDetails = _recipeBookService.GetRecipeDetailsByRecipe(recipeId);
            return Ok(receipeDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipeDetail(int id)
        {
            var recipeDetail = _recipeBookService.GetRecipeDetail(id);
            if (recipeDetail == null)
            {
                return NotFound();
            }
            return Ok(recipeDetail);

        }

        [HttpPost]
        public IActionResult CreateDetailForRecipe(int recipeId, [FromBody] RecipeDetail recipeDetail)
        {
            if (recipeDetail == null)
            {
                return BadRequest();
            }
            if (!_recipeBookService.RecipeExists(recipeId))
            {
                return NotFound();
            }
            _recipeBookService.AddRecipeDetailForRecipe(recipeId, recipeDetail);
            if (!_recipeBookService.Save()) {
                throw new Exception("Not saved");
            }

            return CreatedAtRoute("GetDetails", recipeDetail);

        }
    }
}