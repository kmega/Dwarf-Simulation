﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Cards;

namespace Core.Usecases.CardComparison
{
    public class RankCardComparisonStrategy : ICardComparisonStrategy
    {
        public bool AreTheSame(Card card1, Card card2)
        {
            if ((card1.Rank() == card2.Rank()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
