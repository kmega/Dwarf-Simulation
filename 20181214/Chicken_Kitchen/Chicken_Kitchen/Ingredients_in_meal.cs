using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken_Kitchen
{
    class Ingredients_in_meal
    {
        public IDictionary<Food, List<Ingredient>> _dictionary_ingredients_in_meal;
        public List<Ingredient> _list_ingredients_in_order;
        

        public Ingredients_in_meal()
        {
            _dictionary_ingredients_in_meal = new Dictionary<Food, List<Ingredient>>();

            _dictionary_ingredients_in_meal.Add(Food.Fries, new List<Ingredient>() { Ingredient.Potatoes });
            _dictionary_ingredients_in_meal.Add(Food.Smashed_Potatoes, new List<Ingredient>() { Ingredient.Potatoes });
            _dictionary_ingredients_in_meal.Add(Food.Tuna_Cake, new List<Ingredient>() { Ingredient.Tuna, Ingredient.Chocolate, Ingredient.Asparagus, Ingredient.Milk, Ingredient.Honey });


        }

        public List<Ingredient> list_of_meal_ingredients(List<Food> _order_list)
        {
            _list_ingredients_in_order = new List<Ingredient>();


            
            foreach (var dish in _order_list)
            {
                foreach (var component in _dictionary_ingredients_in_meal[dish])
                {
                    _list_ingredients_in_order.Add(component);
                }
            }

            Console.WriteLine("Ingredients in meal");
            foreach (var item in _list_ingredients_in_order)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            return _list_ingredients_in_order;
        }

    }
}
