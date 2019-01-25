using Core.Entities.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Technical.RanGens
{
    public class AlwaysLastSelector : ICardSelector
    {
        public Card DrawCard(List<Card> cards)
        {
            int lastCard = cards.Count-1;

            return cards[lastCard];
        }
    }
}
