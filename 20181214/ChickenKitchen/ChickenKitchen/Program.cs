using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenKitchen
{
    class Program
    {
     
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> foodDictionary = FoodData.getFoodDictionary("FoodData.txt");
            Customer customer = new Customer("Adam Smith","Fries", new List<string>());
            bool isFoodAllowed = true;
            foreach (string ingradient in foodDictionary[customer.order])
            {
                if (!FoodData.baseIngredients.Contains(ingradient))
                {
                    isFoodAllowed = false;
                    break;
                }
            }
            if (isFoodAllowed) Console.WriteLine(customer.name + " can eat " + customer.order);
            else Console.WriteLine(customer.name + " cant eat " + customer.order);
         
           
            
            




            Console.ReadKey();

        }
    }
}
