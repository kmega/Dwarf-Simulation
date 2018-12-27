using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Croupier 
    {
        
            public List <Cards> CreatePool(Dictionary<CardsTypes, int> bet)
            {
            List<Cards> cards = new List<Cards>();
            
            for (int i = 0; i < bet[CardsTypes.Kier]; i++)
            {
                cards.Add(new Cards() {type = CardsTypes.Kier, value = 1 });
                
            }
            for (int i = 0; i < bet[CardsTypes.Karo]; i++)
            {
                cards.Add(new Cards() { type = CardsTypes.Karo, value = 0 });

            }
            for (int i = 0; i < bet[CardsTypes.Trefl]; i++)
            {
                cards.Add(new Cards() { type = CardsTypes.Trefl, value = -1 });

            }
            return cards;
        }
      

       
    }
}