using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken_Kitchen
{
    class Check_the_order
    {
        public void check_order(List<Ingredient> allergy_list, List<Ingredient> ingredients_in_the_order)
        {
            string result = "It's ok";

            foreach (var order_ingredient in ingredients_in_the_order)
            {
                foreach (var allergy_ingredient in allergy_list)
                {
                    if (order_ingredient == allergy_ingredient)
                    {
                        result = "Bad ingredient " + allergy_ingredient.ToString();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine(result);
        }
    }
}
