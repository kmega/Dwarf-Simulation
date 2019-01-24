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
            CardDeck cardDeck = QueryGameState.ExtractCardDeck(currentGameState);
            cardDeck.DrawRandomCard();
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
