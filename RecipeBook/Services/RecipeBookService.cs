using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBook.DataLayer;
using RecipeBook.Entities;

namespace RecipeBook.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private RecipeBookContext _recipeBookContext;
        public RecipeBookService(RecipeBookContext recipeBookContext)
        {
            _recipeBookContext = recipeBookContext;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            _recipeBookContext.Ingredients.Add(ingredient);
        }

        public void AddCategory(Category category)
        {
            _recipeBookContext.Categories.Add(category);
        }

        public void AddRecipe(Recipe recipe)
        {
            _recipeBookContext.Recipes.Add(recipe);
        }

        public void AddRecipeDetailForRecipe(int recipeId, RecipeDetail recipeDetail)
        {
           // recipeDetail.RecipeId = recipeId;
            _recipeBookContext.RecipeDetails.Add(recipeDetail);
        }

        public void AddStepForRecipe(int recipeId, Step step)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void DeleteRecipeDetail(RecipeDetail recipeDetail)
        {
            throw new NotImplementedException();
        }

        public void DeleteStep(Step step)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetIngredient(int id)
        {
            return _recipeBookContext.Ingredients.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _recipeBookContext.Ingredients.ToList();

        }

        public Category GetCategory(int id)
        {
            return _recipeBookContext.Categories.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _recipeBookContext.Categories.ToList();

        }

        public Recipe GetRecipe(int id)
        {
            return _recipeBookContext.Recipes.FirstOrDefault(a => a.Id == id);
        }

        public RecipeDetail GetRecipeDetail(int id)
        {
           return _recipeBookContext.RecipeDetails.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<RecipeDetail> GetRecipeDetailsByRecipe(int recipeId)
        {
          return  _recipeBookContext.RecipeDetails.Where(a => a.RecipeId == recipeId);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipeBookContext.Recipes.ToList();
        }

        public IEnumerable<Step> GetStepsByRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public bool RecipeExists(int recipeId)
        {
            return _recipeBookContext.Recipes.Any(a => a.Id == recipeId);
        }

        public bool CategoryExists(string categoryName)
        {
            return _recipeBookContext.Categories.Any(a => a.Name.ToLower() == categoryName.ToLower());
        }

        public bool Save()
        {
            return (_recipeBookContext.SaveChanges() >= 0);
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void UpdateRecipeDetail(RecipeDetail recipeDetail)
        {
            throw new NotImplementedException();
        }

        public void UpdateStep(Step step)
        {
            throw new NotImplementedException();
        }
    }
}
