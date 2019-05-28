using System.Collections.Generic;

namespace Tests
{
    public static class BurgerFactory
    {
        public static Burger SimpleBurger()
        {
            var ingredients = new List<Ingredient>
            {
                Ingredients.Bread,
                Ingredients.Meat,
                Ingredients.Ketchup
            };
            return new Burger("Burger", 1.20, ingredients);
        }

        public static Burger CheeseBurger()
        {
            var ingredients = new List<Ingredient>
            {
                Ingredients.Bread,
                Ingredients.Meat,
                Ingredients.Ketchup,
                Ingredients.Cheese

            };
            return new Burger("CheeseBurger", 1.30, ingredients);
        }

        public static Burger ChickenBUrger()
        {
            var ingredients = new List<Ingredient>
            {
                Ingredients.Bread,
                Ingredients.Chicken,
                Ingredients.Ketchup,
                Ingredients.Salad,
                Ingredients.Cheese

            };
            return new Burger("ChickenBurger", 1.60, ingredients);
        }

        public static Burger BaconBurger()
        {
            var ingredients = new List<Ingredient>
            {
                Ingredients.Bread,
                Ingredients.Meat,
                Ingredients.Ketchup,
                Ingredients.Salad,
                Ingredients.Cheese,
                Ingredients.Bacon

            };
            return new Burger("BaconBurger", 3.20, ingredients);
        }

        public static IEnumerable<Burger> AllBurgers()
        {
            yield return SimpleBurger();
            yield return ChickenBUrger();
            yield return BaconBurger();
            yield return CheeseBurger();

        }
    }
}