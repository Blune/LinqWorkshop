namespace Tests
{
    public struct Ingredient
    {
        public Ingredient(string name, double price, int calories)
        {
            Name = name;
            Price = price;
            Calories = calories;
        }
        public string Name { get; }
        public double Price { get; }
        public double Calories { get; }
    }
}