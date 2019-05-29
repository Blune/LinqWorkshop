using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tests;

namespace LinqWorkshop
{
    public class RefactoringExample
    {
        [Test]
        public void AllBurgersWithSaladImperative()
        {
            var burgers = BurgerFactory.AllBurgers();

            var ingredientMap = new Dictionary<Ingredient, int>();
            foreach (var burger in burgers)
            {
                foreach (var ingredient in burger.Ingredients)
                {
                    if (ingredient.Price > 0.2)
                    {
                        int count;
                        if (!ingredientMap.TryGetValue(ingredient, out count))
                        {
                            ingredientMap.Add(ingredient, 1);
                        }
                        else
                        {
                            ingredientMap[ingredient] = count + 1;
                        }
                    }
                }
            }

            string result = "";
            foreach (var pair in ingredientMap)
            {
                if (result != "")
                {
                    result += ", ";
                }
                result += pair.Key.Name + ": " + pair.Value;
            }

            Assert.AreEqual("Meat: 3, Chicken: 1, Bacon: 1", result);
        }

        [Test]
        public void AllBurgersWithSaladExpressive()
        {
            var text = BurgerFactory.AllBurgers()
                .SelectMany(burger => burger.Ingredients)
                .Where(ingredient => ingredient.Price > 0.2)
                .GroupBy(ingredient => ingredient)
                .ToDictionary(group => group.Key, group => group.Count())
                .Select(pair => pair.Key.Name + ": " + pair.Value)
                .Aggregate((result, s) => result + ", " + s);

            Assert.AreEqual("Meat: 3, Chicken: 1, Bacon: 1", text);
        }
    }
}
