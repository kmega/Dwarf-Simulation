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
            if (QueryGameState.AmountOfCardsLeft(currentGameState) % 2 == 0)
            {
                CardDeck deck = QueryGameState.ExtractCardDeck(currentGameState); //wyciagam karty
                deck.AddASingleCard(new Card("10", "C"));
            }
            else
            {
                CardDeck deck = QueryGameState.ExtractCardDeck(currentGameState);
                deck.DrawRandomCard();
            }

        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
