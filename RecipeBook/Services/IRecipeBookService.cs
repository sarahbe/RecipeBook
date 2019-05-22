using RecipeBook.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Services
{
    public interface IRecipeBookService
    {
        //Recipe
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        void AddRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(Recipe recipe);

        //Ingredient
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(int id);
        void AddIngredient(Ingredient ingredient);
        void UpdateIngredient(Ingredient ingredient);
        void DeleteIngredient(Ingredient ingredient);

        //Step 
        IEnumerable<Step> GetStepsByRecipe(int recipeId);
        void AddStepForRecipe(int recipeId, Step step);
        void UpdateStep(Step step);
        void DeleteStep(Step step);

        //RecipeDetail
        IEnumerable<RecipeDetail> GetRecipeDetailsByRecipe(int recipeId);
        RecipeDetail GetRecipeDetail(int id);
        void AddRecipeDetailForRecipe(int recipeId, RecipeDetail recipeDetail);
        void UpdateRecipeDetail(RecipeDetail recipeDetail);
        void DeleteRecipeDetail(RecipeDetail recipeDetail);


        bool RecipeExists(int recipeId);
        bool Save();

    }
}
