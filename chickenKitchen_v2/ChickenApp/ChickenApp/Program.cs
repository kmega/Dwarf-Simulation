using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChickenApp.Domain;

namespace ChickenApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.Create customers with allergies
            //2. Create menu and allergens
            //3. Call waiter and order a meal
            Waiter waiter = new Waiter();

            waiter.CallWaiter();

            Console.ReadKey();
        }
    }
}
