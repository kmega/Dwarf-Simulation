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
        //public int Points { get; set; }
        public List<Deck.AllCards> FightPool { get; set; }


        public Player()
        {

        }

        public Player(PlayersName name)
        {
            Name = name;
            FightPool = new List<Deck.AllCards>();
        }

        /// <summary>
        /// Transfer top card from hand to the top position in fight pool
        /// </summary>
        /// <param name="hand">Pool hand</param>
        /// <param name="fightPool"></param>
        public static void TransferCard(List<Deck.AllCards> hand, List<Deck.AllCards> fightPool)
        {
            fightPool.Add(hand[hand.Count - 1]);
            hand.RemoveAt(hand.Count - 1);
        }

        /// <summary>
        /// Transfer all cards from fight pools to the bottom of hand
        /// </summary>
        /// <param name="hand">Pool hand</param>
        /// <param name="fightPool1"></param>
        /// <param name="fightPool2"></param>
        public static void TransferFightPoolsToHand(List<Deck.AllCards> hand, List<Deck.AllCards> fightPool1, List<Deck.AllCards> fightPool2)
        {
            hand.InsertRange(0, fightPool1);
            hand.InsertRange(0, fightPool2);
            ClearFightPools(fightPool1, fightPool2);
        }

        private static void ClearFightPools(List<Deck.AllCards> fightPool1, List<Deck.AllCards> fightPool2)
        {
            fightPool1.Clear();
            fightPool2.Clear();
        }
    }
}
