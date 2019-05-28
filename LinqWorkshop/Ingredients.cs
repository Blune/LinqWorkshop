namespace Tests
{
    public static class Ingredients
    {
        public static Ingredient Bread => new Ingredient("Bread", 0.1, 63);
        public static Ingredient Meat => new Ingredient("Meat", 0.52, 44);
        public static Ingredient Chicken => new Ingredient("Chicken", 0.48, 44);
        public static Ingredient Salad => new Ingredient("Salad", 0.01, 1);
        public static Ingredient Tomato => new Ingredient("Tomato", 0.03, 4);
        public static Ingredient Onions => new Ingredient("Onions", 0.03, 4);
        public static Ingredient Cucumber => new Ingredient("Cucumber", 0.02, 3);
        public static Ingredient Cheese => new Ingredient("Cheese", 0.10, 13);
        public static Ingredient Bacon => new Ingredient("Bacon", 0.22, 30);
        public static Ingredient Ketchup => new Ingredient("Ketchup", 0.06, 30);
        public static Ingredient Mayonaise => new Ingredient("Mayonaise", 0.09, 39);
    }
}