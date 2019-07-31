using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Entities;
using RecipeBook.Services;
using RecipeBook.Helpers;

namespace RecipeBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IRecipeBookService _recipeBookService;
        public CategoriesController(IRecipeBookService recipeBookService)
        {
            _recipeBookService = recipeBookService;
        }

        [HttpGet(Name = "GetCategories")]
        public IActionResult GetCategories()
        {
            var categories = _recipeBookService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _recipeBookService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        //FromBody means that the parameter needs to be deserielized.
        [HttpPost]
        public IActionResult CreateIngredient([FromBody]Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (_recipeBookService.CategoryExists(category.Name))
            {
                ModelState.AddModelError(nameof(Category), "Category already exists! Try using the available one ;)");
            }

            if (!ModelState.IsValid)
            {
                return new Helpers.UnprocessableEntityObjectResult(ModelState);
            }

            _recipeBookService.AddCategory(category);
            if (!_recipeBookService.Save())
            {
                throw new Exception("Not saved!");
            }

            return CreatedAtRoute("GetCatgeories", category);
        }

    }
}