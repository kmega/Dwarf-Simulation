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
            Card drawn = cards[cards.Count - 1];
            return drawn;
        }
    }
}
