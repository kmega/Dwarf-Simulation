using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCardGame.Enum;

namespace WarCardGame.Domain
{
   class Cards
    {
        public string Name;
        public StrengthOfCards CardStrength;

        public Cards (StrengthOfCards cardStrength, string name)
	    {
            this.Name = name;
            this.CardStrength = cardStrength;
	    }

    }

   class CardDeck
    {
        Cards c_1 = new Cards(StrengthOfCards.two,"two");
        Cards c_2 = new Cards(StrengthOfCards.three,"three");
        Cards c_3 = new Cards(StrengthOfCards.four,"four");
        Cards c_4 = new Cards(StrengthOfCards.five,"five");
        Cards c_5 = new Cards(StrengthOfCards.six,"six");
        Cards c_6 = new Cards(StrengthOfCards.seven,"seven");
        Cards c_7 = new Cards(StrengthOfCards.eight,"eight");
        Cards c_8 = new Cards(StrengthOfCards.nine,"nine");
        Cards c_9 = new Cards(StrengthOfCards.ten,"ten");
        Cards c_10 = new Cards(StrengthOfCards.jack,"jack");
        Cards c_11 = new Cards(StrengthOfCards.queen,"queen");
        Cards c_12 = new Cards(StrengthOfCards.king,"king");
        Cards c_13 = new Cards(StrengthOfCards.ace,"ace");

        public List<Cards> Deck()
        {
            List<Cards> cardsDeck = new List<Cards>();

            for (int i = 0; i < 4; i++)
            {
                cardsDeck.Add(c_1);
                cardsDeck.Add(c_2);
                cardsDeck.Add(c_3);
                cardsDeck.Add(c_4);
                cardsDeck.Add(c_5);
                cardsDeck.Add(c_6);
                cardsDeck.Add(c_7);
                cardsDeck.Add(c_8);
                cardsDeck.Add(c_9);
                cardsDeck.Add(c_10);
                cardsDeck.Add(c_11);
                cardsDeck.Add(c_12);
                cardsDeck.Add(c_13);
            }

            return cardsDeck;
        }

        public List<Cards> ShuffleDeck(List<Cards> deck)
        {
            Random randomNumber = new Random();
            for (int i=0; i < deck.Count; i++)
            {
                int randomN = randomNumber.Next(0, deck.Count);
                Cards value = deck[randomN];
                deck[randomN] = deck[i];
                deck[i] = value;

                Console.WriteLine(randomN);
            }


            return deck;
        }

    }   
    
}
