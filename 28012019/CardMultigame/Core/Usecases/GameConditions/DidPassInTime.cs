using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameConditions
{
    public class DidPassInTime : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            object result = currentGameState["Guess"];

            if (result != null)
            {
                bool isGameWon = (result as bool?).Value;
                if(isGameWon)
                {
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
                }
            }
        }
    }
}
