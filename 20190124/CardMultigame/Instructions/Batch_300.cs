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
using System.Linq;

namespace TrainingTests
{

    public class Batch_300
    {

        [Test]
        public void T_301_GenerateDeckForBlackjack()
        {
            // Given
            CardDeck createdDeck = new CardDeckFactory().Simple9ToKWith4Colours();

            // Expected
            CardDeck expectedDeck = new CardDeckFactory()
                                .FromGivenCards("9S 9H 9D 9C 10S 10H 10D 10C JS JH JD JC " +
                                                "QS QH QD QC KS KH KD KC");

            // When


            // Then
            Assert.AreSame(createdDeck, expectedDeck);

        }
    }

}
