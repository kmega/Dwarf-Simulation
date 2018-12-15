using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            //0.) Stworzenie Klienta ( Przedstawienie klienta i w konstruktorze podanie swoich alergii)
            Client Adam_Smith = new Client(new List<Enums.AllergicBase>
            {
                {Enums.AllergicBase.Pickles }, {Enums.AllergicBase.Feta}, {Enums.AllergicBase.Water }, {Enums.AllergicBase.Rice}, {Enums.AllergicBase.Milk}
            }
            );

            //1.) Przyjęcie zamówienia
            Meal order = new Meal(Enums.Meal.Fries);
            //2.) Sprawdzenie czy osoba zamawiająca nie jest uczulona na składnik jej potrawy
            bool result = CheckingAllergens(Adam_Smith, order);
            if(result == false)
            {
                Console.WriteLine("Nie możesz tego zjeść");
            }
            else
            {
                Console.WriteLine("Smacznego!");
            }

            //3.) Jeśli osoba uczulona na składnik podanie komunikatu, że nie może zjeść tego posiłku
            //3.) Jeśli osoba nie jest uczulona na żaden składnik, podanie dania

            Console.ReadKey();
        }

        private static bool CheckingAllergens(Client person, Meal orderOfMeal)
        {
            bool result = true;
            for (int i = 0; i < person.allergens.Count ; i++)
            {
                foreach (var ingredient in orderOfMeal.MealWithBasicIngredients[orderOfMeal.order_key])
                {
                    if (person.allergens[i] == ingredient)
                    {
                        Console.WriteLine("Jestes uczulony na: " + ingredient);
                        result = false;
                    }
                }

            }

           // int i = 0;

            //foreach (var allergen in orderOfMeal.MealWithBasicIngredients)
            //{
            //    foreach (var item in orderOfMeal.MealWithBasicIngredients[allergen])
            //    {
            //        if (person.allergens[i] == item) Console.WriteLine("Jestes uczulony na : " + item); return false;
            //    }
            //}
            return result;
        }
    }
}
