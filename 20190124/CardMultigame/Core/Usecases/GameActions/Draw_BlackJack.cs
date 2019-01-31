using System;
using System.Collections.Generic;
using System.Text;
using Core.Containers.GameRules;
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
            modifiedDeck.DrawLastAddedCard();

            PointsCardComparsionStrategy countPoints = new PointsCardComparsionStrategy();

            
                int points = (int)currentGameState[GameStateKeys.CurrentTurn];
                points += countPoints.CompareForPoints(modifiedDeck.DrawLastAddedCard(), orderParams);

                currentGameState[GameStateKeys.CurrentTurn] = points;

            
        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
