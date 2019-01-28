using System;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameConditions
{
    public class DidCardsExceeded21 : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            object result = currentGameState["Blackjack"];

            if (result != null)
            {
                bool isGameWon = (result as bool?).Value;
                if (isGameWon)
                {
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
                }
            }
        }
    }
}
