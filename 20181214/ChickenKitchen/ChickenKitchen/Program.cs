using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{

    public enum Ingredients
    {
        Chicken, Tuna,
        Potatoes, Asparagus,
        Milk, Honey, Paprika,
        Garlic, Water, Lemon, Tomatoes,
        Pickles, Feta, Vinegar,
        Rice, Chocolate, none

    }
    class Program
    {
        public static Boolean CheckIngredients(Klient klient, Order dinner)
        {
            if (klient.allergy == dinner.ingredientsToOrder)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void PrepareMeal(Order dinner, Dictionary<Ingredients, int> store, Klient klient)
        {
            if (store.ContainsKey(dinner.ingredientsToOrder))
            {
                store[dinner.ingredientsToOrder] -= 1;
                Console.WriteLine("We prepared {0} for {1} and it cost 1 {2}",
                    dinner.orderName, klient.name, dinner.ingredientsToOrder);
            }
        }

        static void Main(string[] args)
        {
            //1.User->klientName, order
            //2.CheckIngredients: a)klientName in klientbase? b) klientAllerg in ingredients?
            //3.PrepareMeal (order.ingredients from magazine) ->user(name,order,cost)

            Klient klient = new Klient("Adam Smith", Ingredients.none);
            Order dinner = new Order("Fries", Ingredients.Potatoes);
            Dictionary<Ingredients, int> store = new Dictionary<Ingredients, int>
            {
                {Ingredients.Potatoes, 10 }
            };

            if (CheckIngredients(klient, dinner))
            {
                Console.WriteLine("This meal will kill you");
            }
            else
            {
                PrepareMeal(dinner, store, klient);
            }

            Console.ReadKey();
        }


    }


}