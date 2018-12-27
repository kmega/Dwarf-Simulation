using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class DifficultLevel
    {
        public void GetDifficultLevel(Dictionary<CardsTypes, int> bet, string choice)
        {
            bet[CardsTypes.Karo] += 3;
                switch (choice)
                {
                    case "1":
                        bet[CardsTypes.Kier] += 2;
                    bet[CardsTypes.Trefl] += 4;
                    break;
                    case "2":
                        bet[CardsTypes.Trefl] += 6;
                        break;
                    case "3":
                        bet[CardsTypes.Kier] -= 2;
                    bet[CardsTypes.Trefl] += 8;

                    break;
                    default:
                        Console.WriteLine("Podałeś błędną wartość, wróć jak powtórzysz czytanie");
                    Console.ReadKey();
                    System.Environment.Exit(1);
                    break;

                }

            Console.WriteLine("Twoja ręka to:");
            foreach (var item in bet)
            {
                Console.WriteLine(item.Key + " x " + item.Value);
            }
            }
    }
}
