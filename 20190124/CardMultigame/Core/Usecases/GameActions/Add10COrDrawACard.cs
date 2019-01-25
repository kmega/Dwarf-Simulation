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
            //throw new NotImplementedException("Implement this for T203 ChainSomeCommands");
            CardDeck currentDeck = QueryGameState.ExtractCardDeck(currentGameState);
            if ((currentDeck.CardsLeft() % 2) != 0)
            {
                currentDeck.AddASingleCard(new Card("10", "C"));
            }
            else
            {
                currentDeck.DrawRandomCard();
            }
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
