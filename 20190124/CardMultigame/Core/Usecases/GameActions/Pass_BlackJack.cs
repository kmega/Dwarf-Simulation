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
    public class Pass_BlackJack : IGameAction
    {
        public void ChangeGameState(GameState currentGameState, PlayedGameRules gameRules, string orderParams)
        {
            CardDeck modifiedDeck = QueryGameState.ExtractCardDeck(currentGameState);
            Card drawnCard = modifiedDeck.DrawLastAddedCard();

            PointsCardComparsionStrategy countPoints = new PointsCardComparsionStrategy();
            int points = countPoints.CompareForPoints(drawnCard, orderParams);

            if (points <= (int)currentGameState[GameStateKeys.CurrentTurn])
                currentGameState["IsGameWon"] = true;
            else
                currentGameState["IsGameWLost"] = true;

        }

        public bool ShouldReactTo(string item1)
        {
            throw new NotImplementedException();
        }
    }
}
