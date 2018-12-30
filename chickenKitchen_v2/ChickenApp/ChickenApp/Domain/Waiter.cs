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

            string ingredientDish = GetIndgredientOutOfDish(orderedDish);

            if (ingredientDish == "") Console.WriteLine("ERROR!");

            foreach ( string dishAlergens in allergensInFood[ingredientDish])
            {
                foreach (string customersAllergie in allergiesOfCustomers[name])
                {
                    if (dishAlergens == customersAllergie) { isAlergic = true; }
                }
            }

            return isAlergic;
        }

        private string GetIndgredientOutOfDish(string orderedDish)
        {
            Menu dishes = new Menu();
            Dictionary<string, List<string>> allergensInFood = dishes.FoodAndAllergens();

            string dishIngredient = "";

            foreach(string dish in allergensInFood[orderedDish])
            {
                
                if (allergensInFood.ContainsKey(dish)) { GetIndgredientOutOfDish(dish); }
                else { dishIngredient = dish; }
            }

            return dishIngredient;
        }
    }
}
