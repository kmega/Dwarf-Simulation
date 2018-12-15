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
       
        static void Main(string[] args)
        {
            //1.User->klientName, order
            //2.CheckIngredients: a)klientName in klientbase? b) klientAllerg in ingredients?
            //3.PrepareMeal (order.ingredients from magazine) ->user(name,order,cost)

            Klient klient = new Klient(
                "Adam Smith",
               new Ingredients[] { Ingredients.none }
                );

            Order dinner = new Order(
                "Ruby Salad",
                new Ingredients[] {Ingredients.Tomatoes, Ingredients.Vinegar }
                );

            Dictionary<Ingredients, int> store = new Dictionary<Ingredients, int>
            {
                {Ingredients.Potatoes, 10 },
                {Ingredients.Tomatoes, 10 },
                {Ingredients.Vinegar, 10 }
            };

            MasterChef pascal = new MasterChef();
            pascal.PrepareMeal(dinner, store, klient);
            

            Console.ReadKey();
        }


    }


}