﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeBook.Entities;

namespace RecipeBook.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        public void AddIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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