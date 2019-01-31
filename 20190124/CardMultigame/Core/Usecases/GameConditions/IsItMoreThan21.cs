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
            try
            {
                if ((int)currentGameState[GameStateKeys.CurrentTurn] >= (int)currentGameState[GameStateKeys.MaxTurns] && (bool)currentGameState["IsGameLost"] == true)
                {
                    ModifyGameState.DeclareGameToBeLost(currentGameState);
                }

                if ((int)currentGameState[GameStateKeys.CurrentTurn] == (int)currentGameState[GameStateKeys.MaxTurns] || (bool)currentGameState["IsGameWon"] == true)
                {
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
                }
            }
            catch (Exception)
            {

                
            }
            
        }
    }
}
