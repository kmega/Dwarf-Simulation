using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Containers.GameRules;
using Core.Entities.GameStates;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class AddQueenOfHeartsToDeck : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            CardDeck temp = QueryGameState.ExtractCardDeck(currentGameState);
            CardDeck temp1 = temp;
            Card xd;
            if(ShouldReactTo("QH"))
            {
                xd = new CardFactory().CreateSingle("QH");
                temp1.AddASingleCard(xd);
            }

            temp = temp1;

            //throw new NotImplementedException("Implement this for T202 Add Queen of Hearts");
        }

        public bool ShouldReactTo(string item1)
        {
            if(item1 == "QH")
            {
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }
    }
}
