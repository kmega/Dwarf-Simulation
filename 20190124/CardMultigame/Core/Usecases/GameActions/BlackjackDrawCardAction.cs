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
    public class BlackjackDrawCardAction : IGameAction
    {
        string _identifier = "LastDrawnCard";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            CardDeck currentDeck = QueryGameState.ExtractCardDeck(currentGameState);
            Card drawnCard = currentDeck.DrawRandomCard();
            currentGameState["LastDrawnCard"] = drawnCard;

            switch (drawnCard.Rank())
            {
                case "9":
                    currentGameState["LastDrawnCardValue"] = 2;
                    break;
                case "10":
                    currentGameState["LastDrawnCardValue"] = 3;
                    break;
                case "J":
                    currentGameState["LastDrawnCardValue"] = 4;
                    break;
                case "Q":
                    currentGameState["LastDrawnCardValue"] = 5;
                    break;
                case "K":
                    currentGameState["LastDrawnCardValue"] = 6;
                    break;
                default:
                    break;
            }

            currentGameState["Points"] = currentGameState["LastDrawnCardValue"] as int?;
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
