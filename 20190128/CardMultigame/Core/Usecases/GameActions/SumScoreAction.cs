using System;
using System.Collections.Generic;
using System.Text;
using Core.Containers.GameRules;
using Core.Entities.Cards;
using Core.Entities.GameStates;

namespace Core.Usecases.GameActions
{
    public class SumScoreAction : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            int value = Card.GetCardValue(currentGameState[GameStateKeys.LastDrawnCard] as Card);
            var currentScore = currentGameState[GameStateKeys.BlackJackScore] as int?;
            if (currentScore == null) currentScore = 0;
            currentScore += value;
            currentGameState[GameStateKeys.BlackJackScore] = currentScore;
        }        

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
