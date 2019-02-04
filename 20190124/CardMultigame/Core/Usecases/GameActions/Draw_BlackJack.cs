using System;
using System.Collections.Generic;
using System.Text;
using Core.Containers.GameRules;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class Draw_BlackJack : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            CardDeck modifiedDeck = QueryGameState.ExtractCardDeck(currentGameState);
            Card drawnCard = modifiedDeck.DrawLastAddedCard();

            PointsCardComparsionStrategy countPoints = new PointsCardComparsionStrategy();

            
                int points = (int)currentGameState[GameStateKeys.CurrentTurn];
                points += countPoints.CompareForPoints(drawnCard, orderParams);

                currentGameState[GameStateKeys.CurrentTurn] = points;

            if ((int)currentGameState[GameStateKeys.CurrentTurn] > 20)
            {
                currentGameState["IsGameLost"] = true;
                currentGameState["IsGameWon"] = false;
            }
                
            else
            {
                currentGameState["IsGameLost"] = false;
                currentGameState["IsGameWon"] = true;
            }

        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
