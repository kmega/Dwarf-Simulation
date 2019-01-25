﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameConditions
{
    /// <summary>
    /// If there exists a 'Guess' key in the gameState AND the value is true, 
    /// declare game has been won.
    /// </summary>
    public class DidGuessACard : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            if(currentGameState.ContainsKey("Guess"))
            {
                if ((bool)currentGameState["Guess"] == true)
                {
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
                }
            }
            //throw new NotImplementedException("Im?plement this for T208 WinCondition, LossCondition");
        }
    }
}
