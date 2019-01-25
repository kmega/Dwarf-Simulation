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
            string card1Colour;
            string card2Colour;

            if (card1.Colour() == "S" || card1.Colour() == "C")
                card1Colour = "Black";
            else
                card1Colour = "Red";


            if (card2.Colour() == "S" || card2.Colour() == "C")
                card2Colour = "Black";
            else
                card2Colour = "Red";


            if (card1Colour == card2Colour)
            {
                return true;
            }
            else
                return false;



            // Spades, Clubs (S, C) -> black
            // Hearts, Diamonds (H, D) -> red
        }
    }
}
