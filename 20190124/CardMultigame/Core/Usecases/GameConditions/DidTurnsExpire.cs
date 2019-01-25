using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameConditions
{
    /// <summary>
    /// If currentTurn >= maxTurns: declare game has been lost.
    /// </summary>
    public class DidTurnsExpire : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {

            if ((int)currentGameState[GameStateKeys.CurrentTurn] == 0)
            {
                ModifyGameState.DeclareGameToBeLost(currentGameState);

            }
        }
    }
}
