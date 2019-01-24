using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Cards;

namespace Core.Usecases.CardComparison
{
    public class BlackRedColourOnlyComparisonStrategy : ICardComparisonStrategy
    {
        public bool AreTheSame(Card card1, Card card2)
        {
            string[] card_color = new string[2];
            string[] card_char = new string[2];

            card_char[0] = card1.Colour();
            card_char[1] = card2.Colour();
            for (int i = 0; i <= 1; i++)
            {
                switch (card_char[i])
                {
                    case "H":
                    case "D":
                        card_color[i] = "red";
                        break;
                    case "S":
                    case "C":
                        card_color[i] = "black";
                        break;
                }
            }

            if (card_color[0]==card_color[1])
            {
                return true;
            }
            {
                return false;
            }
        }
    }
}
