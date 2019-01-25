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
            CardDeck TransformedGameStateToDeck = QueryGameState.ExtractCardDeck(currentGameState);

            if(TransformedGameStateToDeck.CardsLeft() % 2 == 0)
            {
                TransformedGameStateToDeck.AddASingleCard(new CardFactory().CreateSingle("10C"));
                return;
            }

            TransformedGameStateToDeck.DrawRandomCard();

            //throw new NotImplementedException("Implement this for T203 ChainSomeCommands");
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
