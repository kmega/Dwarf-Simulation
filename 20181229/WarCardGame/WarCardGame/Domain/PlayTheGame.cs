using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCardGame.Domain;
using WarCardGame.Enum;

namespace WarCardGame.Domain
{
    class PlayTheGame
    {
        public void PlayMainEngine(List<Cards> deck_1, List<Cards> deck_2)
        {
            bool play = true;

            while (play == true)
            {
                List<Cards> table = new List<Cards>();

                Cards card_1 = TakeFirstCardFromDeck(deck_1);
                Cards card_2 = TakeFirstCardFromDeck(deck_2);

                table.Add(card_1);
                table.Add(card_2);


                bool compareResult = CompareCardsIsDraw(card_1, card_2);

                if (compareResult == false) { RoundWinner(card_1, card_2, deck_1, deck_2, table); }
                else
                {
                    while (compareResult == true)
                    {
                        Console.WriteLine("Player_1 war card: {0}, Player_2 war card: {1}", card_1.Name, card_2.Name);
                        card_1 = TakeFirstCardFromDeck(deck_1);
                        card_2 = TakeFirstCardFromDeck(deck_2);
                        Console.WriteLine("Player_1 war covered card: {0}, Player_2 war covered card: {1}", card_1.Name, card_2.Name);
                        table.Add(card_1);
                        table.Add(card_2);

                        card_1 = TakeFirstCardFromDeck(deck_1);
                        card_2 = TakeFirstCardFromDeck(deck_2);

                        table.Add(card_1);
                        table.Add(card_2);

                        compareResult = CompareCardsIsDraw(card_1, card_2);

                    }

                    RoundWinner(card_1, card_2, deck_1, deck_2, table);
                    play = CheckDecksNotNull(deck_1, deck_2, card_1, card_2);
                    if (play == false) { break; }
                }

               play = CheckDecksNotNull(deck_1, deck_2, card_1, card_2);

            }
        }

        private bool CheckDecksNotNull(List<Cards> deck_1, List<Cards> deck_2, Cards card_1, Cards card_2)
        {

            bool play;
            if (deck_1.Count == 0 || card_1.CardStrength == 0)
            {
                CallWinner("Player_2");
                play = false;
            }
            else if (deck_2.Count == 0 || card_2.CardStrength == 0)
            {
                CallWinner("Player_1");
                play = false;
            }
            else { play = true; }

            return play;
        }

        private void CallWinner(string winner)
        {
            Console.WriteLine("The winner is {0}!",winner);
        }

        private void RoundWinner(Cards card_1, Cards card_2, List<Cards> deck_1, List<Cards> deck_2, List<Cards> table)
        {
            Console.WriteLine("Player_1: {0}, Player_2: {1}", card_1.Name, card_2.Name);
            if (card_1.CardStrength > card_2.CardStrength) { UpdateDeckAfterRound(deck_1, table); }
            else { UpdateDeckAfterRound(deck_2, table);  }

        }

        public bool CompareCardsIsDraw(Cards card_1, Cards card_2)
        {
            if (card_1.CardStrength != card_2.CardStrength ) { return false; }
            else if ( card_1.CardStrength == 0 || card_2.CardStrength == 0) { return true; }
            else { return true; }
        }
        
        public List<Cards> UpdateDeckAfterRound(List<Cards> deck, List<Cards> table)
        {
            for (int i = 0;  i < table.Count; i++)
            {
                deck.Add(table[i]);
            }

            return deck;
        }

        public Cards TakeFirstCardFromDeck(List<Cards> deck)
        {
            if (deck.Count != 0)
            {
                Cards card = deck[0];
                deck.RemoveAt(0);

                return card;
            }
            else
            {
                
                Cards nullCard = new Cards(StrengthOfCards.blank,"blank");

                return nullCard;
            }
            
        }
    }
}
