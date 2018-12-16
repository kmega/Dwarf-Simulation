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
               new Ingredients[] { Ingredients.Asparagus }
                );

            List<Order> menu = new List<Order>() {

                new Order("Ruby Salad", new Ingredients[] {Ingredients.Tomatoes,Ingredients.Vinegar}),
                new Order ("Fries", new Ingredients[] {Ingredients.Potatoes}),
                new Order ("Youth Sauce", new Ingredients[]{Ingredients.Asparagus, Ingredients.Milk, Ingredients.Honey}),
                
            };
            menu.Add(new Order("Princess Chicken", new Ingredients[] { Ingredients.Chicken }, "Youth Sauce", menu));
        

            Dictionary<Ingredients, int> store = new Dictionary<Ingredients, int>
            {
                {Ingredients.Potatoes, 10 },
                {Ingredients.Tomatoes, 10 },
                {Ingredients.Vinegar, 10 },
                {Ingredients.Asparagus, 10 },
                {Ingredients.Chicken, 10 },
                {Ingredients.Honey,10 },
                {Ingredients.Milk,10 }
            };

            MasterChef pascal = new MasterChef();
            pascal.PrepareMeal(menu[3], store, klient);
            

            Console.ReadKey();
        }


    }


}