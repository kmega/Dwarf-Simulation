using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen.RestaurantDataBase
{
    public class Menu
    {

        public List<Order> menu;

        public Menu()
        {
            menu = new List<Order>() {

                new Order("Ruby Salad", new List<Ingredients> {Ingredients.Tomatoes,Ingredients.Vinegar}),
                new Order ("Fries", new List<Ingredients> {Ingredients.Potatoes}),
                new Order ("Spicy Sauce", new List<Ingredients> {Ingredients.Paprika,Ingredients.Garlic,Ingredients.Water}),
                new Order ("Youth Sauce", new List<Ingredients>{Ingredients.Asparagus, Ingredients.Milk, Ingredients.Honey}),
                new Order ("Diamond Salad", new List<Ingredients>{Ingredients.Tomatoes, Ingredients.Pickles,Ingredients.Feta})

            };
            menu.Add(new Order("Princess Chicken", new List<Ingredients> { Ingredients.Chicken },
               new string[] { "Youth Sauce" }, menu));

            menu.Add(new Order("Fat Cat Chicken", new List<Ingredients> { },
                new string[] { "Princess Chicken", "Youth Sauce", "Fries", "Diamond Salad" }, menu));
            menu.Add(new Order("Tuna Cake", new List<Ingredients> { Ingredients.Chocolate, Ingredients.Tuna },
                new string[] { "Youth Sauce" }, menu));
            menu.Add(new Order("Emperor Chicken", new List<Ingredients> { },
                new string[] { "Fat Cat Chicken", "Spicy Sauce", "Tuna Cake" }, menu));


        }
    }
}
