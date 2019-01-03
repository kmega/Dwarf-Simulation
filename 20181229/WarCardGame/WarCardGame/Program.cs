using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCardGame.Domain;
using WarCardGame.Enum;

namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Create two decks
            CardDeck deck = new CardDeck();
            List<Cards> deck_1 = deck.Deck();
            List<Cards> deck_2 = deck.Deck();

            //2. Shuffle the decks
            List<Cards> shuffledDeck_1 = deck.ShuffleDeck(deck_1);
            List<Cards> shuffledDeck_2 = deck.ShuffleDeck(deck_2);
 
            //3. Play (show how the game went)
            PlayTheGame gameStart = new PlayTheGame();
            gameStart.PlayMainEngine(shuffledDeck_1,shuffledDeck_2);

            //4. Announce the winner
            Console.ReadKey();
        }
    }
}
