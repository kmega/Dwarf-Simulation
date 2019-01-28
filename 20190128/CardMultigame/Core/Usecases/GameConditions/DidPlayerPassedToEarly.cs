using Core.Entities.Cards;
using Core.Entities.GameStates;
using Core.Usecases.GameConditions;
using Core.Usecases.InfluenceState;
using System;

namespace Core.Entities.Games.BlackJack
{
    public class DidPlayerPassedToEarly : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            if(Convert.ToBoolean(currentGameState[GameStateKeys.DidPlayerPassed]) == true)
            {
                Card nextCard= QueryGameState
                    .ExtractCardDeck(currentGameState).DrawRandomCard();
                int? finalScore = currentGameState[GameStateKeys.BlackJackScore] as int?;
                if(finalScore + Card.GetCardValue(nextCard) <= 21)
                {
                    ModifyGameState.DeclareGameToBeLost(currentGameState);
                }
                else
                {
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
                }

            }
        }
    }
}