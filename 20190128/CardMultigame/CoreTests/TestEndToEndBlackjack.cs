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
        public void Draws9H_AndValueIs2()
        {
            CardDeck deck = new CreateCardDeck().FromGivenCards("9H"); //, JH, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawSingleCardAction(),
            };

            // Expected:
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 1);
            int amountOfCardsAfterDrawingOne = 0;

            // When
            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Then
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == amountOfCardsAfterDrawingOne);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(gameState) == 2);
        }

        [Test]
        public void Draws9H_And_KH_ValueIs8()
        {
            CardDeck deck = new CreateCardDeck().FromGivenCards("9H, KH"); //, JH, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawSingleCardAction(),
                new DrawSingleCardAction(),
                //new DrawSingleCardAction(),
                //new DrawSingleCardAction(),     // now it should be empty
                //new AddQueenOfHeartsToDeck(),
                //new AddQueenOfHeartsToDeck(),
                //new Add10COrDrawACard(),        // should add +1 card, because even
                //new Add10COrDrawACard()         // should draw a card, because odd
            };

            // Expected:
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 2);
            int amountOfCardsAfterDrawingOne = 0;

            // When
            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Then
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == amountOfCardsAfterDrawingOne);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(gameState) == 8);
        }

        [Test]
        public void FinalValueIsOver21AndGameIsLost()
        {
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, KH, KH, KH"); 
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawSingleCardAction(),
                new DrawSingleCardAction(),
                new DrawSingleCardAction(),
                new PassBlackjack()
            };

            // Expected:
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 4);
            int amountOfCardsAfterDrawingOne = 0;

            // When
            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Then
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == amountOfCardsAfterDrawingOne);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(gameState) == 24);
            Assert.IsTrue(QueryGameState.IsGameLost(gameState) == true);
        }

        [Test]
        public void FinalValueIs21AndGameIsWon()
        {
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, KH, KH, 10H");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawSingleCardAction(),
                new DrawSingleCardAction(),
                new DrawSingleCardAction(),
                new PassBlackjack()
            };

            // Expected:
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 4);
            int amountOfCardsAfterDrawingOne = 0;

            // When
            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Then
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == amountOfCardsAfterDrawingOne);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(gameState) == 21);
            Assert.IsTrue(QueryGameState.IsGameWon(gameState) == true);
        }
    }
}
