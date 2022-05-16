using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models.viewmodel
{
    public class FilterModel
    {

        public Boolean Vegan { get; set; }
        public Boolean Vegetarian { get; set; }
        public Boolean Regional { get; set; }
        public Filter Filter { get; set; }
        public List<Recipe> Recipes { get; set; }

        public FilterModel() : this(false, false, false, Filter.Choose, null) { }

        public FilterModel(bool vegan, bool vegetarian, bool regional, Filter filter, List<Recipe> rep)
        {
            this.Vegan = vegan;
            this.Vegetarian = vegetarian;
            this.Regional = regional;
            this.Filter = filter;
            this.Recipes = rep;
        }

    }
}
