using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsWar.GameEngine
{
    class Game
    {
        private Deck _cards = new Deck();
        private List<Deck.AllCards> _shuffledCards = new List<Deck.AllCards>();

        public static void Run(bool permissionStart)
        {
            if (permissionStart)
            {
                Game game = new Game();
                game.Play();
            }

            
        }

        private void Play()
        {

            //1. Shuffle cards -> List<cards> shuffled cards;           
            _shuffledCards = _cards.Shuffle();
                       

            //2. Make two hands of cards from deck -> two lists of cards
            //2.1 (List<cards> firstHand, List<cards> secondHand) = GenerateHands(deck);

            //3. Doing wars
            //3.1 winner = War.Fight(firstHand, secondHand); // return winner (opponent or you)

            //4. Show summary UI
            //4.1 SummaryUI.Display(winner);
        }

    }
}
