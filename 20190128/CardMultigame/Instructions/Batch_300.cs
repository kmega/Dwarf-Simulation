using Core.Containers.GameManagers.Rules.CreationCommands;
using Core.Containers.GameRules;
using Core.Containers.GameRules.CreationCommands;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.Games;
using Core.Entities.Games.BlackJack;
using Core.Entities.GameStates;
using Core.GameManagers.SelectedRules;
using Core.Usecases.CardComparison;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using Core.Usecases.InfluenceState;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
namespace Instructions
{
    class Batch_300
    {
        [Test]
        public void T_301_WinConditionLossCondition()
        {
            // Commentary
            // ---
            // To be able to understand the core loop of this program we need to build a different
            // type of command - the Conditions type of command.
            // 
            // We are going to implement two Conditions: DidGuessACard and DidTurnsExpire.
            //
            // We will: 
            // * chain two DrawSingleActionCards together
            // * chain DidPlayerPassedToEarly and IsPlayerScoreGreaterThan21
            //
            // And they should:
            // * IsPlayerScoreGraterThan21 is supposed to set loss (ModifyGameState.DeclareGameToBeWon) IF 'Score' is greater than 21.
            // * DidTurnsExpire is supposed to set a loss (ModifyGameState.DeclareGameToBeLost) IF player passedScore += nextCard == 21.
            //
            // Also, look at the structure of 'When' in this test.
            // THIS is the core game loop.  If you look at GameManager, you will see the same concept, 
            // but with slightly different implementation.
            //
            // Two Chains of Responsibility.
            // ---

            // Given
            GameState gameState = new CreateGameState().DefaultsPlusDeck(
                new CreateCardDeck().Simple9ToKWith4Colours());

            string actionsToPerform = "drawSingleCard, sumScore, " +
                "drawSingleCard, sumScore, drawSingleCard, sumScore, drawSingleCard, sumScore," +
                " drawSingleCard, sumScore";
            List<IGameAction> actions = new CreateGameActions().HavingOrders(actionsToPerform);

            List<IGameCondition> conditions = new List<IGameCondition>()
            {
                new IsPlayerScoreGreaterThan21(),
                new DidPlayerPassedToEarly()
            };

            // When

            do
            {
                foreach (var action in actions)
                {
                    action.ChangeGameState(gameState, null, null);
                }

                foreach (var condition in conditions)
                {
                    condition.CheckAndUpdate(gameState);
                }

            } while (QueryGameState.IsGameFinished(gameState) == false);

            // Then
            Assert.IsTrue(QueryGameState.IsGameLost(gameState) == true);
            Assert.IsTrue(QueryGameState.IsGameWon(gameState) == false);
        }
        [Test]
        public void T_312_ImplementGuessACardCommand()
        {
            // Commentary
            // ---
            // Now, time for a fun task. You know everything needed to implement GuessACard command:
            // * You know how PlayedRules and GameState are made (via builder)
            // * You know what the GuessACard command is:
            //   * It draws a card like the 'DrawSingleCard' command
            //   * It uses a CardComparator taken from Rules to match the card with the one from the parameter
            //     * If it matches it, it puts 'Guess' with 'true'.
            //     * If it doesn't match it, it puts 'Guess' with 'false'.
            //   * It adds +1 turn (method of GameState).
            // Good luck ;-)
            // ---

            // Given
            GameManagerInternalsBuilder builder = new GameManagerInternalsBuilder();

            List<ICreateGameRulesCommand> commands = new List<ICreateGameRulesCommand>()
            {
                new SelectGame(),
            };

            List<string> arguments = new List<string>() { "BlackJack" };

            for (int i = 0; i < commands.Count; i++)
            {
                commands[i].ChangeGameRuleset(builder, arguments[i]);
            }

            PlayedGameRules rules = builder.ConstructRuleset();
            GameState gameState = builder.ConstructGameState();

            Assert.IsTrue(QueryGameState.AmountOfCardsLeft(gameState) == 20);

            IGameAction action = new DrawSingleCardAction();

            // When
            // First draw
            action.ChangeGameState(gameState, rules, null);

            // Then
            Assert.IsTrue(gameState[GameStateKeys.BlackJackScore] as int? >= 2);

            // When
            // Pass 
            action = new PassTurn();
            action.ChangeGameState(gameState, rules, null);

            // Then
            Assert.IsTrue(gameState["Guess"] as bool? == true);

        }
    }
}
