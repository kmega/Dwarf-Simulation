using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Cards
{
    public class Card
    {
        private string _rank;
        private string _colour;

        public Card(string rank, string colour)
        {
            this._rank = rank;
            this._colour = colour;
        }

        public string Rank() => _rank;
        public string Colour() => _colour;
        public static int GetCardValue(Card card)
        {
            switch (card.Rank())
            {
                case "9":
                    return 2;
                case "10":
                    return 3;
                case "J":
                    return 4;
                case "Q":
                    return 5;
                case "K":
                    return 6;
                default:
                    return 0;
            }
        }
    }
}
