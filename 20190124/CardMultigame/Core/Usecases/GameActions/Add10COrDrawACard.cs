using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Entities.Cards;
using Core.Usecases.InfluenceState;
using Core.Entities.Decks;

namespace Core.Usecases.GameActions
{
    public class Add10COrDrawACard : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            CardDeck cardDeck = QueryGameState.ExtractCardDeck(currentGameState);
            int deckSize = cardDeck.CardsLeft();
            if (deckSize % 2 == 0)
                cardDeck.AddASingleCard(new Card("10", "C"));
            else
                new DrawSingleCardAction().ChangeGameState(currentGameState, null, null);


        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
