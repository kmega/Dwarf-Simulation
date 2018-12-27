using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
   public class HandStrenght
    {
        public void GetHandStrenght (Dictionary <CardsTypes,int> bet, string choice)
        {
            switch (choice)
            {
                case "1":
                    bet[CardsTypes.Kier] += 3;
                    break;
                case "2":
                    bet[CardsTypes.Kier] += 6;
                    break;
                case "3":
                    bet[CardsTypes.Kier] += 9;
                    break;
                default:
                    Console.WriteLine("Podałeś błędną wartość to będziesz mieć trudno");
                    break;

            }

        }
    }
}
