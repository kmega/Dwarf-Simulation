using System;
using System.Collections.Generic;

namespace ChickenApp.Domain
{
    class Waiter
    {
        public void CallWaiter()
        {
            Console.WriteLine("Hello, what is Your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What would You like to order, {0}", name);
            string dish = Console.ReadLine();

            bool isAllergicTo = isCusomerAlergicToOrderedDish(name, dish);

            string answer = (isAllergicTo == false) ? "Here's Your meal" : "You're allergic to it";

            Console.WriteLine(answer);
        }

        private bool isCusomerAlergicToOrderedDish(string name, string orderedDish)
        {
            Menu dishes = new Menu();
            Customers customer = new Customers();

            Dictionary<string, List<string>> allergensInFood = dishes.FoodAndAllergens();
            Dictionary<string, List<string>> allergiesOfCustomers = customer.CustomersAndAllergies();
            bool isAlergic = false;

            List<string> ingredientDish = GetIndgredientOutOfDish(orderedDish);

            if (ingredientDish == null) Console.WriteLine("ERROR!");

            for (int i=0; i< ingredientDish.Count; i++)
            {
                foreach (string dishAlergens in allergensInFood[ingredientDish[i]])
                {
                    foreach (string customersAllergie in allergiesOfCustomers[name])
                    {
                        if (dishAlergens == customersAllergie) { isAlergic = true; }
                    }
                }
            }

            return isAlergic;
        }


        private List<string> GetIndgredientOutOfDish(string orderedDish)
        {
            List<string> foodFromIngredients = new List<string>();

            foodFromIngredients = GetFoodOutOfDish(orderedDish);
            int i = 0;
            do
            {
                foreach ( string food in GetFoodOutOfDish(foodFromIngredients[i]))
                {
                    foodFromIngredients.Add(food);
                }

                i++;

            } while (GetFoodOutOfDish(foodFromIngredients[i-1]) != null);

            return foodFromIngredients;
            
        }

        private List<string> GetFoodOutOfDish(string orderedDish)
        {
            Menu dishes = new Menu();
            Dictionary<string, List<string>> allergensInFood = dishes.FoodAndAllergens();
            List<string> foodInsteadOfIngredients = new List<string>();

            foreach (string dish in allergensInFood[orderedDish])
            {
                if (allergensInFood.ContainsKey(dish)) { foodInsteadOfIngredients.Add(dish); }

            }

            return foodInsteadOfIngredients;
        }
    }
}
