using System;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Usecases.GameConditions;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class PassBlackjack : IGameAction, IGameCondition
    {
        string _identifier = "Pass";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            new DrawSingleCardForBlackjack().ChangeGameState(currentGameState, gameRules, orderParams);

            if((int)currentGameState[GameStateKeys.CurrentCardsValue] == 21)
            {
                currentGameState[GameStateKeys.IsGameWon] = true;
            }
            else
            {
                currentGameState[GameStateKeys.IsGameLost] = true;
            }
        }

        public void CheckAndUpdate(GameState currentGameState)
        {
            object result = currentGameState["Pass"];

            if (result != null)
            {
                bool isGameWon = (result as bool?).Value;
                if (isGameWon)
                {
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
                }
            }
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
