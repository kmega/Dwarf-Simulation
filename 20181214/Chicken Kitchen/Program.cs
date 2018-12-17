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
            //accept order
            restaurant.AcceptOrder(restaurant.ChooseClient(), restaurant.ChooseFood());




            Console.ReadKey();
            //create food
        }
    }
}
