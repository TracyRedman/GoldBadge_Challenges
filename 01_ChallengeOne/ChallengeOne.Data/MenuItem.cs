using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class MenuItem
    {
        public MenuItem(){}
        public MenuItem(string name)
        {
            Name = name;
        }
        public MenuItem(string name, string description, List<string> ingredients, decimal price)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal Price { get; set; }
    }

