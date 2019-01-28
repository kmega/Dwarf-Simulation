using System;
using System.Collections.Generic;
using Core.Entities.Decks;
using Core.Entities.Games;
using Core.Entities.GameStates;
using Core.Interface;
using Core.Usecases.GameActions;
using Core.Usecases.InfluenceState;
using NUnit.Framework;

namespace CoreTests
{
    public class TestEndToEndBlackjack
    {
        [Test]
        public void SimpleVariantHasProperSetup()
        {
            // Given
            string input = "SETUP cat; Play Blackjack;";

            var dispatcher = new UiLogicDispatcher();

            // When
            dispatcher.SetupGame(input);

            // Then
            string result = dispatcher.DisplayCurrentState();

            Assert.IsTrue(result.Contains("[CurrentTurnNumber, 0]"));
            Assert.IsTrue(result.Contains("[MaximumTurns, 20]"));
        }

        [Test]
        public void Temp()
        {
            CardDeck deck = new CreateCardDeck().FromGivenCards("9H, JH, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawSingleCardAction(),
                //new DrawSingleCardAction(),
                //new DrawSingleCardAction(),     // now it should be empty
                //new AddQueenOfHeartsToDeck(),
                //new AddQueenOfHeartsToDeck(),
                //new Add10COrDrawACard(),        // should add +1 card, because even
                //new Add10COrDrawACard()         // should draw a card, because odd
            };

            // Expected:
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 3);
            int amountOfCardsAfterDrawingOne = 2;

            // When
            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Then
           //Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == amountOfCardsAfterDrawingOne);
        }
    }
}
