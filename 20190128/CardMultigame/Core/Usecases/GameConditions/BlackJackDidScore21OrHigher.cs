using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameConditions
{
   public class BlackJackDidScore21OrHigher : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            object result = currentGameState["Points"];

            if (result != null)
            {

                if ((result as int?).Value > 21)
                {
                    ModifyGameState.DeclareGameToBeLost(currentGameState);
                }
            }
        }
    }
}
