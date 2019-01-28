using Core.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTests
{
    class BlackJackTestEndToEnd
    {
        [Test]
        public void SimpleVariantHasProperSetup()
        {
            // Given
            string input = "SETUP cat; Play BlackJack;";

            var dispatcher = new UiLogicDispatcher();

            // When
            dispatcher.SetupGame(input);

            // Then
            string result = dispatcher.DisplayCurrentState();

            Assert.IsTrue(result.Contains("[CurrentTurnNumber, 0]"));
            Assert.IsTrue(result.Contains("[MaximumTurns, 20]"));

        }
    }
}
