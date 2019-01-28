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
            //if(orderParams == null)
            //{
            //    List<string> keys = new List<string>(currentGameState.Keys);
            //    CardDeck deck = currentGameState[keys[0]] as CardDeck;
            //    deck.DrawRandomCard();
            //}

            CardDeck modifiedDeck = QueryGameState.ExtractCardDeck(currentGameState);
            modifiedDeck.DrawRandomCard();

            if (modifiedDeck.CardsLeft() == 0)
                currentGameState["Guess"] = true;
            else
                currentGameState["Guess"] = false;


        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
