using Core.Entities.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Usecases.CardComparison
{
    public class PointsCardComparsionStrategy:ICardComparisonStrategy
    {
        public bool AreTheSame(Card card1, Card card2)
        {
            throw new NotImplementedException();
        }

        public int CompareForPoints(Card card, string orderParams)
        {
            int cardPoints = 0;

            if(orderParams == "eye")
            {
                switch (card.Rank())
                {
                    case "9":
                        cardPoints = 2;
                        return cardPoints;
                    case "10":
                        cardPoints = 3;
                        return cardPoints;
                    case "J":
                        cardPoints = 4;
                        return cardPoints;
                    case "Q":
                        cardPoints = 5;
                        return cardPoints;
                    case "K":
                        cardPoints = 6;
                        return cardPoints;

                }
            }
            return cardPoints;
        }
    }
}
