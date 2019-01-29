using System;
using System.Collections.Generic;
using System.Text;
using Core.Containers.GameRules;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class BlackJackDraw : IGameAction
    {

        string _identifier = "Points";
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            CardDeck deck = QueryGameState.ExtractCardDeck(currentGameState);
            Card actuallyDrawnCard = deck.DrawRandomCard();

            switch (actuallyDrawnCard.Rank())
            {
                case "9":
                   currentGameState[_identifier] = (int)currentGameState[_identifier] + 2;
                    break;
                case "10":
                    currentGameState[_identifier] = (int)currentGameState[_identifier] + 3;
                    break;
                case "J":
                    currentGameState[_identifier] = (int)currentGameState[_identifier] + 4;
                    break;
                case "Q":
                    currentGameState[_identifier] = (int)currentGameState[_identifier] + 5;
                    break;
                case "K":
                    currentGameState[_identifier] = (int)currentGameState[_identifier] + 6;
                    break;
                    default:
                    currentGameState[_identifier] = (int)currentGameState[_identifier] + 0;
                    break;





            }
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
