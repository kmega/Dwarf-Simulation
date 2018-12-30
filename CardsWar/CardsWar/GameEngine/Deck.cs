using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsWar.GameEngine
{
    
    public class Deck
    {

        public enum AllCards
        {
            one = 1, two, three, four, five, six, seven, eight, nine, ten, jack, queen, king, ace
        }

        private List<AllCards> deck = new List<AllCards>
        {AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
        AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace,
        AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
        AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace,
        AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
        AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace,
        AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
        AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace};

        public List<AllCards> Shuffle()
        {
            Random rnd = new Random();

            for (int i = 0; i < deck.Count; i++)
            {               
                var temp = deck[i];
                int randomIndex = rnd.Next(0, deck.Count);
                deck[i] = deck[randomIndex];
                deck[randomIndex] = temp;
            }

            return deck;
        }
    }
}