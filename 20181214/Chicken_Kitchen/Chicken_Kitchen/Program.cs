using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chicken_Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {

            //User -> Name, Last_Name
            Client client = new Client();
            client._name = "Adam";
            client._last_name = "Smith";
            client.all_Name = Customer.Bernard_Unfortunate;

            //User -> Order
            Order order = new Order();
            order._whole_order = "Fries";
            order.foods.Add(Food.Fries);


            //Order -> Ingredients<>
            Ingredients_in_meal meal = new Ingredients_in_meal();
            List<Ingredient> list_of_meal_ingredients = meal.list_of_meal_ingredients(order.foods);


            //Name, Last_Name -> Allergy_Ingredients[]
            Allergy_Ingredients allergy = new Allergy_Ingredients();
            List<Ingredient> allergy_list = allergy.list_of_allergy_ingredients(client.all_Name);

            //Ingredients_in_meal<>, Allergy_Ingredients<> -> Compare() -> Result(true, false)
            Check_the_order check = new Check_the_order();
            check.check_order(allergy_list, list_of_meal_ingredients);
            Console.ReadKey();
        }
    }
}
