using System;
namespace mvc.Models.viewmodel
{
    public enum Occasion
    {
        Breakfast, Dinner, Lunch, Picknick, Snack, notSpecified
    }
    public enum Origin
    {
        Austria, Germany, Russia, Mexico, Croatia, Japan, Serbia, Spain,Turkey, USA, China
    }
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string Recipename { get; set; }
        public int Calories { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public Occasion? Occasion { get; set; }
        public bool Regional { get; set; }
        public Origin? Origin { get; set; }
        public string Instructions { get; set; }
        public string Ingredients { get; set; }
        public DateTime DateAdded { get; set; }

        public Recipe() : this(0, "", 0, false, false, 0.0m, 0, null, true,null, "", "", DateTime.Now) { }
        public Recipe(int recipeID, string recipename, int calories, bool vegan, bool vegetarian, decimal price,
            int duration, Occasion? occasion, bool regional, Origin? origin, string instructions, string ingredients, DateTime dateAdded)
        {
            this.RecipeID = recipeID;
            this.Recipename = recipename;
            this.Calories = calories;
            this.Vegan = vegan;
            this.Vegetarian = vegetarian;
            this.Price = price;
            this.Duration = duration;
            this.Occasion = occasion;
            this.Regional = regional;
            this.Origin = origin;
            this.Instructions = instructions;
            this.Ingredients = ingredients;
            this.DateAdded = dateAdded;
        }
    }
}
