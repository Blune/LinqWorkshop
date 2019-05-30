using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public static class DoubleExtension
    {
        public static double TwoDigits(this double d) => Math.Round(d, 2);
    }
    public static class StringExtension
    {
        public static string ToText(this IEnumerable<string> xs) => string.Join(", ", xs);
    }

    public class Tests
    {
        [Test]
        public void IngredientCostOfBurger()
        {
            var burger = BurgerFactory.SimpleBurger();
            var price = burger.Ingredients.Sum(ingredient => ingredient.Price);
            Assert.AreEqual(0.68, price.TwoDigits());
        }

        [Test]
        public void AverageCostOfBurgerIngredient()
        {
            var burger = BurgerFactory.BaconBurger();
            var price = burger.Ingredients.Average(ingredient => ingredient.Price);
            Assert.AreEqual(0.17, price.TwoDigits());
        }

        [Test]
        public void CheapestBurgerIngredientPrice()
        {
            var burger = BurgerFactory.BaconBurger();
            var price = burger.Ingredients.Min(ingredient => ingredient.Price);
            Assert.AreEqual(0.01, price.TwoDigits());
        }

        [Test]
        public void MostExpensiveBurgerIngredientPrice()
        {
            var burger = BurgerFactory.BaconBurger();
            var price = burger.Ingredients.Max(ingredient => ingredient.Price);
            Assert.AreEqual(0.52, price.TwoDigits());
        }

        [Test]
        public void AllBurgersHaveAPrce()
        {
            var burgers = BurgerFactory.AllBurgers();
            var allBurgersArePriced = burgers.All(burger => burger.Price > 0.0);
            Assert.IsTrue(allBurgersArePriced);
        }

        [Test]
        public void CountOfIngredients()
        {
            var burger = BurgerFactory.BaconBurger();
            var numberOfIngredients = burger.Ingredients.Count();
            Assert.AreEqual(6, numberOfIngredients);
        }

        [Test]
        public void NameOfAllIngredients()
        {
            var burger = BurgerFactory.SimpleBurger();
            var ingredientNames = burger.Ingredients.Select(ingredient => ingredient.Name);
            Assert.AreEqual("Bread, Meat, Ketchup", ingredientNames.ToText());
        }

        [Test]
        public void SameIngredientsOfTwoBurgers()
        {
            var burger = BurgerFactory.SimpleBurger();
            var baconBurger = BurgerFactory.BaconBurger();
            var ingredientNames = baconBurger.Ingredients
                                    .Intersect(burger.Ingredients)
                                    .Select(ingredient => ingredient.Name);
            Assert.AreEqual("Bread, Meat, Ketchup", ingredientNames.ToText());
        }

        [Test]
        public void DifferentIngredientsOfTwoBurgers()
        {
            var burger = BurgerFactory.SimpleBurger();
            var baconBurger = BurgerFactory.BaconBurger();
            var ingredientNames = baconBurger.Ingredients.Except(burger.Ingredients).Select(ingredient => ingredient.Name);
            Assert.AreEqual("Salad, Cheese, Bacon", ingredientNames.ToText());
        }


        [Test]
        public void IngredientsWithCaloriesOfBurger()
        {
            var burger = BurgerFactory.SimpleBurger();
            var ingredientNames = burger.Ingredients
                .Aggregate("The ingredients are:", (current, next) => current + " " + $"{next.Name}({next.Calories.ToString()}cal)");
            Assert.AreEqual("The ingredients are: Bread(63cal) Meat(44cal) Ketchup(30cal)", ingredientNames);
        }

        [Test]
        public void AllBurgersThatAreMoreExpensiveThan2Euro()
        {
            var burgers = BurgerFactory.AllBurgers();
            var expensiveBurgers = burgers
                .OrderByDescending(burger => burger.Price)
                .TakeWhile(burger => burger.Price > 2.0)
                .Select(burger => burger.Name);
            Assert.AreEqual("BaconBurger", expensiveBurgers.ToText());
        }

        [Test]
        public void AllBurgersWithSalad()
        {
            var burgers = BurgerFactory.AllBurgers();
            var ingredients = burgers
                .Where(burger => burger.Ingredients.Contains(Ingredients.Salad))
                .Select(ingredient => ingredient.Name);
            Assert.AreEqual("ChickenBurger, BaconBurger", ingredients.ToText());
        }

        [Test]
        public void AllUsedIngredientsOfAllBurgersGroupedByOccurenceAndName()
        {
            var burgers = BurgerFactory.AllBurgers();
            var ingredients = burgers
                .SelectMany(burger => burger.Ingredients)
                .GroupBy(ingredient => ingredient)
                .OrderBy(group => group.Count())
                .ThenBy(group => group.Key.Name)
                .Select(group => group.Key.Name);
            Assert.AreEqual("Bacon, Chicken, Salad, Cheese, Meat, Bread, Ketchup", ingredients.ToText());
        }
    }
}
