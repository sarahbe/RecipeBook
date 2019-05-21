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

        public void AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void AddRecipeDetailForRecipe(int recipeId, RecipeDetail recipeDetail)
        {
            throw new NotImplementedException();
        }

        public void AddStepForRecipe(int recipeId, Step step)
        {
            throw new NotImplementedException();
        }

        public void DeleteIngredient(Ingredient ingredient)
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

        public Recipe GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public RecipeDetail GetRecipeDetail(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RecipeDetail> GetRecipeDetailsByRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Step> GetStepsByRecipe(int recipeId)
        {
            throw new NotImplementedException();
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
