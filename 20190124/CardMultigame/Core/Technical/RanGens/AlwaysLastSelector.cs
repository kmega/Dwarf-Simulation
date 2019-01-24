﻿using Core.Entities.Cards;
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
            var temp = cards.Last();
            cards.Remove(temp);
            return temp;
            //throw new NotImplementedException("Implement this for T112");
        }
    }
}
