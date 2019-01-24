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
        private string _colourName;

        public Card(string rank, string colour)
        {
            this._rank = rank;
            this._colour = colour;
            _colourName = (colour == "D" || colour == "H") ? "red" : "black";
        }

        public string Rank() => _rank;
        public string Colour() => _colour;
        public string ColourName() => _colourName;
       
    }
}
