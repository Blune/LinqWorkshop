using System.Collections.Generic;

namespace Tests
{
    public struct Burger
    {
        public Burger(string name, double price, List<Ingredient> ingredients)
        {
            Name = name;
            Price = price;
            Ingredients = ingredients;
        }
        public string Name { get; }
        public double Price { get; }
        public List<Ingredient> Ingredients { get; }
    }
}