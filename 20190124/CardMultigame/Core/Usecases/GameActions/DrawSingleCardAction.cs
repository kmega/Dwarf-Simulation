using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;
using Core.Entities.Decks;

namespace Core.Usecases.GameActions
{
    public class DrawSingleCardAction : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            //throw new NotImplementedException("Implement this for T201 and I guess change it in T205 too.");
            CardDeck currentDeck = QueryGameState.ExtractCardDeck(currentGameState);
            currentDeck.DrawRandomCard();
            currentGameState["Guess"] = (currentDeck.CardsLeft() == 0) ? true : false;
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
