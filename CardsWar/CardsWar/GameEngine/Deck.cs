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

        private List<AllCards> deck;

        public Deck()
        {
            deck = new List<AllCards>
            {
             AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
             AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace,
             AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
             AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace,
             AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
             AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace,
             AllCards.one, AllCards.two, AllCards.three, AllCards.four, AllCards.five, AllCards.six, AllCards.seven,
             AllCards.eight, AllCards.nine, AllCards.ten, AllCards.jack, AllCards.queen, AllCards.king, AllCards.ace
            };

        }

        public (List<AllCards> firstHand, List<AllCards> secondHand) GenerateTwoHands(List<Deck.AllCards> shuffledCards)
        {
            List<AllCards> firstHand = new List<AllCards>();
            List<AllCards> secondHand = new List<AllCards>();
            for (int i = 0; i < shuffledCards.Count; i++)
            {
                if(i%2 == 0)  //If the index is even, add card to firstHand
                {
                    firstHand.Add(shuffledCards[i]);
                }
                else // If the index is odd, add card to secondHand
                {
                    secondHand.Add(shuffledCards[i]);
                }
            }

            return (firstHand, secondHand);
        }

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
        public static void Shuffle(List<AllCards> deckToShuffle)
        {
            Random rnd = new Random();

            for (int i = 0; i < deckToShuffle.Count; i++)
            {               
                var temp = deckToShuffle[i];
                int randomIndex = rnd.Next(0, deckToShuffle.Count);
                deckToShuffle[i] = deckToShuffle[randomIndex];
                deckToShuffle[randomIndex] = temp;
            }

        }
    }
}