using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Usecases.GameConditions
{
  
    public class IsItMoreThan21 : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {

            if ((int)currentGameState[GameStateKeys.CurrentTurn] >= (int)currentGameState[GameStateKeys.MaxTurns])
            {
                ModifyGameState.DeclareGameToBeLost(currentGameState);
            }

            if ((int)currentGameState[GameStateKeys.CurrentTurn] == (int)currentGameState[GameStateKeys.MaxTurns])
            {
                ModifyGameState.DeclareGameToBeWon(currentGameState);
            }
        }
    }
}
