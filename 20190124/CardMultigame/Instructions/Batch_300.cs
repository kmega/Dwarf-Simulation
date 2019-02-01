using Core.Containers.GameManagers.Rules.CreationCommands;
using Core.Containers.GameRules;
using Core.Containers.GameRules.CreationCommands;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.Games;
using Core.Entities.GameStates;
using Core.GameManagers.SelectedRules;
using Core.Usecases.CardComparison;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using Core.Usecases.InfluenceState;
using NUnit.Framework;
using System.Collections.Generic;
using Core.Interfaces.GameManagers;
using System.Linq;

namespace TrainingTests
{

    public class Batch_300
    {
        [Test]
        public void T_301_AfterFourthDrawScoreOver21()
        {
            // Given primitives
            var cards = new List<string> { 
                "9S", "9H", "9D", "9C",
                "10S", "10H", "10D", "10C",
                "JS", "JH", "JD", "JC", 
                "QS", "QH", "QD", "QC", 
                "KS", "KH", "KD", "KC" };
            var firstDrawCard = "KH";
            var secondDrawCard = "QC";
            var thirdDrawCard = "KS";
            var fourthDrawCard = "QH";
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck +
                "; Draw " + firstDrawCard + "; Draw " + secondDrawCard + 
                "; Draw " + thirdDrawCard + "; Draw " + fourthDrawCard;

            GameManager gm = new GameManagerFactory().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();

            // Then
            Assert.IsTrue(QueryGameState.GameUndergoing(resultReceived) == "Defeat");
        }

        [Test]
        public void T_302_AfterThirdDrawAndPassShouldVictory()
        {
            // Given primitives
            var cards = new List<string> {
                "9S", "9H", "9D", "9C",
                "10S", "10H", "10D", "10C",
                "JS", "JH", "JD", "JC",
                "QS", "QH", "QD", "QC",
                "KS", "KH", "KD", "KC" };
            var firstDrawCard = "KH";
            var secondDrawCard = "QC";
            var thirdDrawCard = "KS";
            var afterPassDrawCard = "QH";
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck +
                "; Draw " + firstDrawCard + "; Draw " + secondDrawCard +
                "; Draw " + thirdDrawCard + "; Pass " + afterPassDrawCard;

            GameManager gm = new GameManagerFactory().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();

            // Then
            Assert.IsTrue(QueryGameState.GameUndergoing(resultReceived) == "Victory");
        }

        [Test]
        public void T_303_AfterThirdDrawAndPassShouldDefeat()
        {
            // Given primitives
            var cards = new List<string> {
                "9S", "9H", "9D", "9C",
                "10S", "10H", "10D", "10C",
                "JS", "JH", "JD", "JC",
                "QS", "QH", "QD", "QC",
                "KS", "KH", "KD", "KC" };
            var firstDrawCard = "KH";
            var secondDrawCard = "QC";
            var thirdDrawCard = "KS";
            var afterPassDrawCard = "JC";
            var secondSeparator = ",";
            string cardsInDeck = string.Join(secondSeparator, cards);

            // Given
            string orders = "Play Blackjack; SetDeck " + cardsInDeck +
                "; Draw " + firstDrawCard + "; Draw " + secondDrawCard +
                "; Draw " + thirdDrawCard + "; Pass " + afterPassDrawCard;

            GameManager gm = new GameManagerFactory().DefaultsWithOrders(orders);

            // When
            gm.ExecuteOrders(orders);
            GameState resultReceived = gm.CurrentState();

            // Then
            Assert.IsTrue(QueryGameState.GameUndergoing(resultReceived) == "Defeat");
        }
    }

}
