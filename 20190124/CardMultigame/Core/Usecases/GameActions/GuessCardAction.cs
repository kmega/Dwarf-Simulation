using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Entities.Cards;
using Core.Containers.GameRules;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;
using Core.Entities.Decks;

namespace Core.Usecases.GameActions
{
    public class GuessCardAction : IGameAction
    {
        string _identifier = "Guess";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            //throw new NotImplementedException("Implement this. T212, GuessingACard command");
            CardDeck currentDeck = QueryGameState.ExtractCardDeck(currentGameState);
            Card chosenCard = new CardFactory().CreateSingle(orderParams);
            Card drawnCard = currentDeck.DrawRandomCard();

            currentGameState["Guess"] = (currentDeck.CardsLeft() == 0) ? true : false;
            currentGameState["Guess"] = (rules.CardComparator().AreTheSame(drawnCard, chosenCard)) ? true : false;
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
