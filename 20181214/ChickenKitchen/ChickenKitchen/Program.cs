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

            List<Order> menu = new List<Order>() {

                new Order("Ruby Salad", new List<Ingredients> {Ingredients.Tomatoes,Ingredients.Vinegar}),
                new Order ("Fries", new List<Ingredients> {Ingredients.Potatoes}),
                new Order ("Youth Sauce", new List<Ingredients>{Ingredients.Asparagus, Ingredients.Milk, Ingredients.Honey}),
                new Order ("Diamond Salad", new List<Ingredients>{Ingredients.Tomatoes, Ingredients.Pickles,Ingredients.Feta})
                
            };
            menu.Add(new Order("Princess Chicken", new List<Ingredients> { Ingredients.Chicken }, 
                new string[] { "Youth Sauce" } , menu));

            menu.Add(new Order("Fat Cat Chicken", new List<Ingredients> { },
                new string[] { "Princess Chicken", "Youth Sauce", "Fries", "Diamond Salad" }, menu));



            Dictionary<Ingredients, int> store = new Dictionary<Ingredients, int>();
            
                foreach (Ingredients item in Enum.GetValues(typeof(Ingredients)))
            {
                store.Add(item, 10);
            }


            MasterChef pascal = new MasterChef();
            pascal.PrepareMeal(menu[5], store, klient);
            

            Console.ReadKey();
        }


    }


}