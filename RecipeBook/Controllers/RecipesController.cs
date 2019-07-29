using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Entities;
using RecipeBook.Models;
using RecipeBook.Services;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        private IRecipeBookService _recipeBookService;
        private IMapper _mapper;
        public RecipesController(IRecipeBookService recipeBookService, IMapper mapper)
        {
            _recipeBookService = recipeBookService;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetRecipes")]
        public IActionResult GetRecipes()
        {
            var recipesFromRepo = _recipeBookService.GetRecipes();

            var recipes = _mapper.Map<IEnumerable<Recipe>, IEnumerable<RecipeViewModel>>(recipesFromRepo);
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRecipe(int id)
        {
            var recipe = _recipeBookService.GetRecipe(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public IActionResult CreateRecipe([FromBody]Recipe recipe)
        {
            if (recipe == null) {
                return BadRequest();
            }
            _recipeBookService.AddRecipe(recipe);

            if (!_recipeBookService.Save())
            {
                throw new Exception("Not saved");
            }

            return CreatedAtRoute("GetRecipes", recipe);
        }
    }
}