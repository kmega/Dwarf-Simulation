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
            //open restaurant
            Restaurant restaurant = new Restaurant();
            //show list of clients
            restaurant.ShowClientsList();
            //show list of foods
            restaurant.ShowFoodList();




            Console.ReadKey();
            //create food
        }
    }
}
