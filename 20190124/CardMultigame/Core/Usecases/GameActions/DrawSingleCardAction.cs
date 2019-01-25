using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class DrawSingleCardAction : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            CardDeck TransformedGameStateToDeck = QueryGameState.ExtractCardDeck(currentGameState);
            TransformedGameStateToDeck.DrawLastAddedCard();

            if (TransformedGameStateToDeck.CardsLeft() == 0)
            {
                currentGameState["Guess"] = true;
            }
            //throw new NotImplementedException("Implement this for T201 and I guess change it in T205 too.");
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
