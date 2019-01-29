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
        private bool ExpectedState = true;

        [Test]
        public void ShouldLoseCase1()
        {
            // For
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, QC, KS, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

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
            Assert.AreEqual(ExpectedState, (bool)gameState[GameStateKeys.IsGameLost]);
        }

        [Test]
        public void ShouldLoseCase2()
        {
            // For
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, QC, KS, JD");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

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
            Assert.AreEqual(ExpectedState, (bool)gameState[GameStateKeys.IsGameLost]);
        }

        [Test]
        public void ShouldWin()
        {
            // For
            CardDeck deck = new CreateCardDeck().FromGivenCards("KH, QC, KS, QH");
            GameState gameState = new CreateGameState().DefaultsPlusDeck(deck);

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
            Assert.AreEqual(ExpectedState, (bool)gameState[GameStateKeys.IsGameWon]);
        }
    }
}
