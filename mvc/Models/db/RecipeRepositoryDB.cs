using System;
using System.Collections.Generic;
using System.Data;
using mvc.Models.viewmodel;
using MySql.Data.MySqlClient;

namespace mvc.Models.db
{
    public class RecipeRepositoryDB : IRecipeRepository
    {
        private string _connectionString = "Server=localhost;Database=dipl_database;UID=root;PWD=root";
        private MySqlConnection _connection;

        public void Open()
        {
            if (this._connection == null)
            {
                this._connection = new MySqlConnection(this._connectionString);
            }

            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }
        public void Close()
        {
            if ((this._connection != null) || (this._connection.State != ConnectionState.Open))
            {
                this._connection.Close();
            }
        }
        public bool ChangeRecipe(int recipeToChange, Recipe newRecipeData)
        {
            if (newRecipeData == null)
            {
                return false;
            }
            try
            {
                MySqlCommand cmdInsert = this._connection.CreateCommand();
                cmdInsert.CommandText = "UPDATE recipes SET recipename = @recipename, vegan = @vegan, vegetarian = @vegetarian, calories = @calories,  duration = @duration, regional = @regional, instruction = @instruction, ingredients = @ingredients , dateadded = @dateadded, filepath = @filepath WHERE id = @id;";
                cmdInsert.Parameters.AddWithValue("recipename", newRecipeData.Recipename);
                cmdInsert.Parameters.AddWithValue("vegan", newRecipeData.Vegan);
                cmdInsert.Parameters.AddWithValue("vegetarian", newRecipeData.Vegetarian);
                cmdInsert.Parameters.AddWithValue("calories", newRecipeData.Calories);
                cmdInsert.Parameters.AddWithValue("duration", newRecipeData.Duration);
                cmdInsert.Parameters.AddWithValue("regional", newRecipeData.Regional);
                cmdInsert.Parameters.AddWithValue("instruction", newRecipeData.Instructions);
                cmdInsert.Parameters.AddWithValue("ingredients", newRecipeData.Ingredients);
                cmdInsert.Parameters.AddWithValue("dateadded", newRecipeData.DateAdded);
                cmdInsert.Parameters.AddWithValue("filepath", newRecipeData.FilePath);
                cmdInsert.Parameters.AddWithValue("id", newRecipeData.RecipeID);
                return cmdInsert.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteRecipe(int recipeToDelete)
        {
            if (recipeToDelete <= 0)
            {
                return false;
            }
            try
            {
                MySqlCommand cmdDelete = this._connection.CreateCommand();
         
                cmdDelete.CommandText = "DELETE FROM recipes WHERE id = @id";
                cmdDelete.Parameters.AddWithValue("id", recipeToDelete);
               
                return cmdDelete.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Recipe> GetAllRecipes()
        {
            try
            {
                List<Recipe> allRecipes = new List<Recipe>();
                MySqlCommand cmdAllRecipes = this._connection.CreateCommand();
                cmdAllRecipes.CommandText = "SELECT * FROM recipes";

                using (MySqlDataReader reader = cmdAllRecipes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allRecipes.Add(new Recipe
                        {
                            RecipeID = Convert.ToInt32(reader["id"]),
                            Recipename = Convert.ToString(reader["recipename"]),
                            Calories = Convert.ToInt32(reader["calories"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            //Price = reader.GetDecimal("price"),
                            Duration = Convert.ToInt32(reader["duration"]),
                            Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                            Regional = Convert.ToBoolean(reader["regional"]),
                            Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                            Instructions = Convert.ToString(reader["instruction"]),
                            Ingredients = Convert.ToString(reader["ingredients"]),
                            DateAdded = Convert.ToDateTime(reader["dateadded"]),
                            FilePath = Convert.ToString(reader["filepath"]),
                        });
                    }
                }
                if (allRecipes.Count > 0)
                {
                    return allRecipes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Recipe GetRecipe(int id)
        {
            Recipe recipe;
            try
            {
                MySqlCommand cmdRecipe = this._connection.CreateCommand();
                cmdRecipe.CommandText = "SELECT * FROM recipes WHERE id = @id";
                cmdRecipe.Parameters.AddWithValue("id", id);

                using (MySqlDataReader reader = cmdRecipe.ExecuteReader())
                {
                    reader.Read();
                    recipe = new Recipe
                    {
                        RecipeID = Convert.ToInt32(reader["id"]),
                        Recipename = Convert.ToString(reader["recipename"]),
                        Calories = Convert.ToInt32(reader["calories"]),
                        Vegan = Convert.ToBoolean(reader["vegan"]),
                        Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                        //Price = Convert.ToDecimal(reader["price"]),
                        Duration = Convert.ToInt32(reader["duration"]),
                        Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                        Regional = Convert.ToBoolean(reader["regional"]),
                        Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                        Instructions = Convert.ToString(reader["instruction"]),
                        Ingredients = Convert.ToString(reader["ingredients"]),
                        DateAdded = Convert.ToDateTime(reader["dateadded"]),
                        FilePath = Convert.ToString(reader["filepath"]),
                    };
                }
                return recipe != null ? recipe : null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertRecipe(Recipe recipeToInsert)
        {
            if (recipeToInsert == null)
            {
                return false;
            }
            try
            {
                MySqlCommand cmdInsert = this._connection.CreateCommand();
                cmdInsert.CommandText = "INSERT INTO recipes VALUES(null,@recipename,@calories, @vegan, @vegetarian, @duration, @occasion ,@regional, @origin, @instruction, @ingredients, @dateadded, @filepath)";
                cmdInsert.Parameters.AddWithValue("recipename", recipeToInsert.Recipename);
                cmdInsert.Parameters.AddWithValue("calories", recipeToInsert.Calories);
                cmdInsert.Parameters.AddWithValue("vegan", recipeToInsert.Vegan);
                cmdInsert.Parameters.AddWithValue("vegetarian", recipeToInsert.Vegetarian);
                //cmdInsert.Parameters.AddWithValue("price", recipeToInsert.Price);
                cmdInsert.Parameters.AddWithValue("duration", recipeToInsert.Duration);
                cmdInsert.Parameters.AddWithValue("occasion", recipeToInsert.Occasion);
                cmdInsert.Parameters.AddWithValue("regional", recipeToInsert.Regional);
                cmdInsert.Parameters.AddWithValue("origin", recipeToInsert.Origin);
                cmdInsert.Parameters.AddWithValue("instruction", recipeToInsert.Instructions);
                cmdInsert.Parameters.AddWithValue("ingredients", recipeToInsert.Ingredients);
                cmdInsert.Parameters.AddWithValue("dateadded", recipeToInsert.DateAdded);
                cmdInsert.Parameters.AddWithValue("filepath", recipeToInsert.FilePath);
                return cmdInsert.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Recipe> GetRecipeWithFilter(bool vegan, bool vegetarian, bool regional)
        {
            try
            {
                List<Recipe> allrep = new List<Recipe>();
                MySqlCommand cmdAllRecipes = this._connection.CreateCommand();
                if(vegan == true)
                {
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where vegan = true;";
                }else if(vegetarian == true){
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where vegetarian = true;";
                }else if(regional == true){
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where regional = true;";
                }else if(vegan == true && vegetarian == true){
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where vegan = true AND vegetarian = true;";
                }else if(vegan == true && regional == true){
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where vegan = true AND regional = true;";
                }else if(vegetarian == true && regional == true){
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where vegetarian = true AND regional = true;";
                }else if(vegetarian == true && vegan == true && regional == true){
                    cmdAllRecipes.CommandText = "SELECT * FROM recipes where vegan = true AND vegetarian = true AND regional = true;";
                }
                using (MySqlDataReader reader = cmdAllRecipes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allrep.Add(new Recipe()
                        {
                            RecipeID = Convert.ToInt32(reader["id"]),
                            Recipename = Convert.ToString(reader["recipename"]),
                            Calories = Convert.ToInt32(reader["calories"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            //Price = reader.GetDecimal("price"),
                            Duration = Convert.ToInt32(reader["duration"]),
                            Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                            Regional = Convert.ToBoolean(reader["regional"]),
                            Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                            Instructions = Convert.ToString(reader["instruction"]),
                            Ingredients = Convert.ToString(reader["ingredients"]),
                            DateAdded = Convert.ToDateTime(reader["dateadded"]),
                            FilePath = Convert.ToString(reader["filepath"]),
                        });
                    }
                }
                if (allrep.Count > 0)
                {
                    return allrep;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
                throw new Exception();
            }
        }
      
        public List<Recipe> GetAllRecipesSixAttribute(string query)
        {
            try
            {
                List<Recipe> allRecipes = new List<Recipe>();
                MySqlCommand cmdAllRecipes = this._connection.CreateCommand();
                cmdAllRecipes.CommandText = query;

                using (MySqlDataReader reader = cmdAllRecipes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allRecipes.Add(new Recipe()
                        {
                            RecipeID = Convert.ToInt32(reader["id"]),
                            Recipename = Convert.ToString(reader["recipename"]),
                            Calories = Convert.ToInt32(reader["calories"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            Price = reader.GetDecimal("price"),
                            Duration = Convert.ToInt32(reader["duration"]),
                            Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                            Regional = Convert.ToBoolean(reader["regional"]),
                            Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                            Instructions = Convert.ToString(reader["instruction"]),
                            Ingredients = Convert.ToString(reader["ingredients"]),
                            DateAdded = Convert.ToDateTime(reader["dateadded"]),
                            FilePath = Convert.ToString(reader["filepath"]),
                        });
                    }
                }
                if (allRecipes.Count > 0)
                {
                    return allRecipes;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
                throw new Exception();
            }
        }
        
        public List<Recipe> GetRecipeWithOrigin(int origin)
        {
            try
            {
                List<Recipe> allRecipes = new List<Recipe>();
                MySqlCommand cmdAllRecipes = this._connection.CreateCommand();
                cmdAllRecipes.CommandText = "SELECT * FROM recipes WHERE origin = @origin";
                cmdAllRecipes.Parameters.AddWithValue("origin", origin);

                using (MySqlDataReader reader = cmdAllRecipes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allRecipes.Add(new Recipe
                        {
                            RecipeID = Convert.ToInt32(reader["id"]),
                            Recipename = Convert.ToString(reader["recipename"]),
                            Calories = Convert.ToInt32(reader["calories"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            //Price = reader.GetDecimal("price"),
                            Duration = Convert.ToInt32(reader["duration"]),
                            Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                            Regional = Convert.ToBoolean(reader["regional"]),
                            Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                            Instructions = Convert.ToString(reader["instruction"]),
                            Ingredients = Convert.ToString(reader["ingredients"]),
                            DateAdded = Convert.ToDateTime(reader["dateadded"]),
                            FilePath = Convert.ToString(reader["filepath"]),

                        });
                    }
                }
                if (allRecipes.Count > 0)
                {
                    return allRecipes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Recipe> RSSFeed()
        {
            try
            {
                List<Recipe> rssfeed = new List<Recipe>();
                MySqlCommand cmdRSSFeed = this._connection.CreateCommand();
                cmdRSSFeed.CommandText = "SELECT * FROM recipes ORDER BY id DESC LIMIT 3";

                using (MySqlDataReader reader = cmdRSSFeed.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rssfeed.Add(new Recipe
                        {
                            RecipeID = Convert.ToInt32(reader["id"]),
                            Recipename = Convert.ToString(reader["recipename"]),
                            Calories = Convert.ToInt32(reader["calories"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            Price = reader.GetDecimal("price"),
                            Duration = Convert.ToInt32(reader["duration"]),
                            Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                            Regional = Convert.ToBoolean(reader["regional"]),
                            Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                            Instructions = Convert.ToString(reader["instruction"]),
                            Ingredients = Convert.ToString(reader["ingredients"]),
                            DateAdded = Convert.ToDateTime(reader["dateadded"]),
                            FilePath = Convert.ToString(reader["filepath"]),
                        });
                    }
                }
                if (rssfeed.Count > 0)
                {
                    return rssfeed;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Recipe> SearchBox(string query)
        { 
            try
            {
                List<Recipe> allRecipes = new List<Recipe>();
                MySqlCommand cmdAllRecipes = this._connection.CreateCommand();
                cmdAllRecipes.CommandText = query;
                

                using (MySqlDataReader reader = cmdAllRecipes.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        allRecipes.Add(new Recipe
                        {
                            RecipeID = Convert.ToInt32(reader["id"]),
                            Recipename = Convert.ToString(reader["recipename"]),
                            Calories = Convert.ToInt32(reader["calories"]),
                            Vegan = Convert.ToBoolean(reader["vegan"]),
                            Vegetarian = Convert.ToBoolean(reader["vegetarian"]),
                            Price = reader.GetDecimal("price"),
                            Duration = Convert.ToInt32(reader["duration"]),
                            Occasion = reader["occasion"] != DBNull.Value ? (Occasion)Convert.ToInt32(reader["occasion"]) : (Occasion?)null,
                            Regional = Convert.ToBoolean(reader["regional"]),
                            Origin = reader["origin"] != DBNull.Value ? (Origin)Convert.ToInt32(reader["origin"]) : (Origin?)null,
                            Instructions = Convert.ToString(reader["instruction"]),
                            Ingredients = Convert.ToString(reader["ingredients"]),
                            DateAdded = Convert.ToDateTime(reader["dateadded"]),
                            FilePath = Convert.ToString(reader["filepath"]),
                        });
                    }
                }
                if (allRecipes.Count > 0)
                {
                    return allRecipes;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
