using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsWar.GameEngine
{
    public class Player
    {
        public enum PlayersName
        {
            You = 1, Opponent
        }

        public PlayersName Name { get; private set; }
        public List<Deck.AllCards> Hand { get; set; }
        public int Points { get; set; }

        public Player()
        {

        }

        public Player(PlayersName name)
        {
            Name = name;
        }
    }
}
