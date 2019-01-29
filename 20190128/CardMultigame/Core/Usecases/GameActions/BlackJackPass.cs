using System;
using System.Collections.Generic;
using System.Text;
using Core.Containers.GameRules;
using Core.Entities.GameStates;

namespace Core.Usecases.GameActions
{
    public class BlackJackPass : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            currentGameState["Pass"] = true;
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
