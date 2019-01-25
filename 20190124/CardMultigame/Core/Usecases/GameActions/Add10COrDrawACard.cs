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
            CardDeck tutorialDeck = QueryGameState.ExtractCardDeck(currentGameState);
            if (tutorialDeck.AllCards().Count() % 2 == 0)
            {

                    tutorialDeck.AddASingleCard(new Card("10", "H"));
            }
            else
            {
                tutorialDeck.DrawRandomCard();
            }
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
