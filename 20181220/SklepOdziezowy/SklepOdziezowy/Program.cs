using SklepOdziezowy.Domena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepOdziezowy
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            shop.TryPants(Enums.EuropeanSize.S);
            shop.BuyCargoFromBasket();
            Console.ReadLine();
        }
    }
}
