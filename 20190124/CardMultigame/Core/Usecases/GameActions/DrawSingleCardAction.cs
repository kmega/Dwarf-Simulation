using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class DrawSingleCardAction : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        { 
            QueryGameState.ExtractCardDeck(currentGameState).DrawLastAddedCard();
            int cards = QueryGameState.ExtractCardDeck(currentGameState).CardsLeft();
            if (cards == 0)
                currentGameState["Guess"] = true;
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
