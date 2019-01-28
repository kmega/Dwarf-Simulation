using System;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class PassBlackjack : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            new DrawSingleCardAction().ChangeGameState(currentGameState, gameRules, orderParams);

            if((int)currentGameState[GameStateKeys.CurrentCardsValuse] == 21)
            {
                currentGameState[GameStateKeys.IsGameWon] = true;
            }
            else
            {
                currentGameState[GameStateKeys.IsGameLost] = true;
            }
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
