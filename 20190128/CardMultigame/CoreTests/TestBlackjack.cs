using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Interfaces.GameManagers;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCasinoTests.Entities
{
    public class TestBlackjack
    {
        [Test]
        public void OhhYeah()
        {
            // Given primitives
            var cards = new List<string> { "JH", "QH", "KH" };
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck + "; SetMaxTurns 20; " +
                "drawBlackjack; drawBlackjack; ";

            GameManager gm = new CreateGameManager().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();


            var temp1 = QueryGameState.MaximumTurns(resultReceived);
            var temp2 = QueryGameState.CurrentTurn(resultReceived);
            // Then
            Assert.IsTrue(QueryGameState.MaximumTurns(resultReceived) == 20);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(resultReceived) == 11);
        }

        [Test]
        public void OhhYea1h()
        {
            // Given primitives
            var cards = new List<string> { "JH", "QH", "KH" };
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck + "; SetMaxTurns 20; " +
                "drawBlackjack; drawBlackjack; Pass;";

            GameManager gm = new CreateGameManager().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();


            var temp1 = QueryGameState.MaximumTurns(resultReceived);
            var temp2 = QueryGameState.CurrentTurn(resultReceived);
            // Then
            Assert.IsTrue(QueryGameState.GameUndergoing(resultReceived) == "Defeat");
            Assert.IsTrue(QueryGameState.MaximumTurns(resultReceived) == 20);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(resultReceived) == 15);
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(resultReceived) == 0);
        }

        [Test]
        public void OhhYea2h()
        {
            // Given primitives
            var cards = new List<string> { "10H", "KH", "KH", "KH" };
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck + "; SetMaxTurns 20; " +
                "drawBlackjack; drawBlackjack; drawBlackjack; Pass;";

            GameManager gm = new CreateGameManager().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();


            var temp1 = QueryGameState.MaximumTurns(resultReceived);
            var temp2 = QueryGameState.CurrentTurn(resultReceived);
            // Then
            Assert.IsTrue(QueryGameState.GameUndergoing(resultReceived) == "Victory");
            Assert.IsTrue(QueryGameState.MaximumTurns(resultReceived) == 20);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(resultReceived) == 21);
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(resultReceived) == 0);
        }

        [Test]
        public void OhhYea3h()
        {
            // Given primitives
            var cards = new List<string> { "KH", "KH", "KH", "KH" };
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck + "; SetMaxTurns 20; " +
                "drawBlackjack; drawBlackjack; drawBlackjack; Pass;";

            GameManager gm = new CreateGameManager().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();


            var temp1 = QueryGameState.MaximumTurns(resultReceived);
            var temp2 = QueryGameState.CurrentTurn(resultReceived);
            // Then
            Assert.IsTrue(QueryGameState.GameUndergoing(resultReceived) == "Defeat");
            Assert.IsTrue(QueryGameState.MaximumTurns(resultReceived) == 20);
            Assert.IsTrue(QueryGameState.CurrentCardsValue(resultReceived) == 24);
            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(resultReceived) == 0);
            Assert.IsTrue(QueryGameState.IsGameLost(resultReceived) == true);


        }
    }
}

