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
        public void T_301_ImplementGuessACardCommand()
        {
            // Given
            GameManagerInternalsBuilder builder = new GameManagerInternalsBuilder();

            List<ICreateGameRulesCommand> commands = new List<ICreateGameRulesCommand>()
            {
                new SelectGame(), new GameVariant(), new SetDeck()
            };

            List<string> arguments = new List<string>() { "Blackjack", "KH,QC,KS,QH" };

            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].ChangeGameRuleset(builder, arguments[i]);
            }

            PlayedGameRules rules = builder.ConstructRuleset();
            GameState gameState = builder.ConstructGameState();

            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 4);

            IGameAction action = new BlackjackDrawCardAction();

            // When
            // First guess is 2S (black), should come a red card, so should be a miss
            action.ChangeGameState(gameState, rules, "2S");

            // Then
            Assert.IsTrue(gameState["Guess"] as bool? == false);

            // When
            // Second guess is 10H (red), should come a red card, so should be a hit
            action.ChangeGameState(gameState, rules, "10H");

            // Then
            Assert.IsTrue(gameState["Guess"] as bool? == true);

        }
    }

}
