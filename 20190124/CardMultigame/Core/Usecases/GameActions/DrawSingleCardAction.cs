using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.Cards;
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
            Card drawnCard = cardDeck.DrawRandomCard();
            currentGameState.Add("DrawnCard", drawnCard);
            if(cardDeck.CardsLeft() == 0)
            {
                currentGameState["Guess"] = true;
            }
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
