using System;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class DrawSingleCardForBlackjack : IGameAction
    {
        string _identifier = "drawBlackjack";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            int currentValue = 0; 

            var DrawedCard = QueryGameState.ExtractCardDeck(currentGameState).DrawLastAddedCard();

            switch (DrawedCard.Rank())
            {
                case "9":
                    currentValue = (int)currentGameState[GameStateKeys.CurrentCardsValue];
                    currentGameState[GameStateKeys.CurrentCardsValue] = currentValue + 2;
                    break;
                case "10":
                    currentValue = (int)currentGameState[GameStateKeys.CurrentCardsValue];
                    currentGameState[GameStateKeys.CurrentCardsValue] = currentValue + 3;
                    break;
                case "J":
                    currentValue = (int)currentGameState[GameStateKeys.CurrentCardsValue];
                    currentGameState[GameStateKeys.CurrentCardsValue] = currentValue + 4;
                    break;
                case "Q":
                    currentValue = (int)currentGameState[GameStateKeys.CurrentCardsValue];
                    currentGameState[GameStateKeys.CurrentCardsValue] = currentValue + 5;
                    break;
                case "K":
                    currentValue = (int)currentGameState[GameStateKeys.CurrentCardsValue];
                    currentGameState[GameStateKeys.CurrentCardsValue] = currentValue + 6;
                    break;
            }

            //if (QueryGameState.AmountOfCardsLeft(currentGameState) == 0)
                //currentGameState["Guess"] = true;
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
