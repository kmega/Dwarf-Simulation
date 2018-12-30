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
        private Player _winner = new Player();

        public static void Run(bool permissionStart)
        {
            Player firstPlayer = new Player(Player.PlayersName.You);
            Player secondPlayer = new Player(Player.PlayersName.Opponent);

            if (permissionStart)
            {
                Game game = new Game();
                game.Play(firstPlayer, secondPlayer);
            }

            
        }

        private void Play(Player firstPlayer, Player secondPlayer)
        {

            //1. Shuffle cards -> List<cards> shuffled cards;           
            _shuffledCards = _cards.Shuffle();

            //2. Make two hands of cards from deck -> two lists of cards
            //2.1 (List<cards> firstHand, List<cards> secondHand) = GenerateHands(deck);
            (firstPlayer.Hand, secondPlayer.Hand) = _cards.GenerateTwoHands(_shuffledCards);

            //3. Doing wars
            _winner = War.Fight(firstPlayer, secondPlayer); // return winner (opponent or you)

            //4. Show summary UI
            //4.1 SummaryUI.Display(winner);
        }

    }
}
