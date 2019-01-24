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
            int lastIndex = cards.Count - 1;
            Card card = cards[lastIndex];
            cards.RemoveAt(lastIndex);
            return card;
        }
    }
}
