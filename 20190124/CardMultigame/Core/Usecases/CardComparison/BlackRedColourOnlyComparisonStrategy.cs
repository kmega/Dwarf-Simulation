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

        // Spades, Clubs (S, C) -> black
        // Hearts, Diamonds (H, D) -> red
        string card1color;
        string card2color;

        public bool AreTheSame(Card card1, Card card2)
        {

          if (card1.Colour() == "S" || card1.Colour() == "C")

            {
                card1color = "black";
            }
          else
            {
                card1color = "red";
            }

            if (card2.Colour() == "S" || card2.Colour() == "C")
            {
                card2color = "black";
            }
            else
            {
                card2color = "red";
            }
            if (card1color == card2color)
            {
                return true;
            }
            return false;
        }
    }
}
