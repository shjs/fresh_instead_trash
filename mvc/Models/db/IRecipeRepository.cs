using System;
using System.Collections.Generic;
using mvc.Models.viewmodel;

namespace mvc.Models.db
{
    public interface IRecipeRepository
    {
        void Open();
        void Close();
        Recipe GetRecipe(int id);
        List<Recipe> GetAllRecipes();
        bool InsertRecipe(Recipe recipeToInsert);
        bool DeleteRecipe(int recipeToDelete);
        bool ChangeRecipe(int recipeToChange, Recipe newRecipeData);
        List<Recipe> GetRecipeWithOrigin(int origin);
        List<Recipe> GetAllRecipesSixAttribute(string query);
        List<Recipe> RSSFeed();
        List<Recipe> SearchBox(string query);


    }
}
