using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Ingredient
    {
        public Ingredient(){}
        public Ingredient(string name)
        {
            Name = name;
        }
        public Ingredient(string name, List<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Name { get; set; }
    }
