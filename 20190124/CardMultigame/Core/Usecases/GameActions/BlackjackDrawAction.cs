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
    public class BlackjackDrawAction : IGameAction
    {
        string _identifier = "Pass";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            CardDeck currentDeck = QueryGameState.ExtractCardDeck(currentGameState);
            Card drawnCard = currentDeck.DrawRandomCard();

            int cardValue = 0;

            switch (drawnCard.Rank())
            {
                case "9":
                    cardValue = 2;
                    break;
                case "10":
                    cardValue = 3;
                    break;
                case "J":
                    cardValue = 4;
                    break;
                case "Q":
                    cardValue = 5;
                    break;
                case "K":
                    cardValue = 6;
                    break;
            }


            int points = 0;
            if (currentGameState["Points"] != null)
                points += (int)currentGameState["Points"];
            points += cardValue;
            currentGameState["Points"] = points;
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
