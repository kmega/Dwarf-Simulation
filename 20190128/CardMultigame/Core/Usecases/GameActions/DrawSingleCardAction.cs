using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class DrawSingleCardAction : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            int currentValue = 0;
            var DrawedCard = QueryGameState.ExtractCardDeck(currentGameState).DrawLastAddedCard();

            switch (DrawedCard.Rank())
            {
                case "9":
                    currentValue = (int)currentGameState["CurrentCardsValuse"];
                    currentGameState["CurrentCardsValuse"] = currentValue + 2;
                    break;
                case "10":
                    currentValue = (int)currentGameState["CurrentCardsValuse"];
                    currentGameState["CurrentCardsValuse"] = currentValue + 3;
                    break;
                case "J":
                    currentValue = (int)currentGameState["CurrentCardsValuse"];
                    currentGameState["CurrentCardsValuse"] = currentValue + 4;
                    break;
                case "Q":
                    currentValue = (int)currentGameState["CurrentCardsValuse"];
                    currentGameState["CurrentCardsValuse"] = currentValue + 5;
                    break;
                case "K":
                    currentValue = (int)currentGameState["CurrentCardsValuse"];
                    currentGameState["CurrentCardsValuse"] = currentValue + 6;
                    break;
            }

            if (QueryGameState.AmountOfCardsLeft(currentGameState) == 0)
                currentGameState["Guess"] = true;
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
