using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.GameActions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTests
{
    class OczkoTests
    {
        [Test]
        public void ShouldLoseCase1()
        {
            // For
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, QC, KS, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            bool expectedState = true;

            // Given
            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawTurnAction(),
                new DrawTurnAction(),
                new DrawTurnAction(),
                new DrawTurnAction()
            };

            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Assert
            Assert.AreEqual(expectedState, (bool)gameState[GameStateKeys.IsGameLost]);
        }

        [Test]
        public void ShouldWinCase2()
        {
            // For
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, QC, KS, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            bool expectedState = true;

            // Given
            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawTurnAction(),
                new DrawTurnAction(),
                new DrawTurnAction(),
                new PassTurnAction()
            };

            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Assert
            Assert.AreEqual(expectedState, (bool)gameState[GameStateKeys.IsGameWon]);
        }

        [Test]
        public void ShouldLoseCase3()
        {
            // For
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, QC, KS, JD");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

            bool expectedState = true;

            // Given
            List<IGameAction> actions = new List<IGameAction>()
            {
                new DrawTurnAction(),
                new DrawTurnAction(),
                new DrawTurnAction(),
                new PassTurnAction()
            };

            foreach (var action in actions)
            {
                action.ChangeGameState(gameState, null, null);
            }

            // Assert
            Assert.AreEqual(expectedState, (bool)gameState[GameStateKeys.IsGameLost]);
        }
    }
}
