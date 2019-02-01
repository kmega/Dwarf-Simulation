using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usecases.GameActions;
using Core.Entities.Games.Guessing;
using Core.Entities.Games;
using Core.Usecases.GameConditions;
using Core.Usecases.CardComparison;
using Core.Entities.GameStates;

namespace Core.Containers.GameRules.CreationCommands
{
    public class SelectGame : ICreateGameRulesCommand
    {
        private string _identifier = "Play";

        public void ChangeGameRuleset(GameManagerInternalsBuilder builder, string parameters)
        {
            //throw new NotImplementedException("Implement this for T210 BuilderRevealsItself");
            switch (parameters)
            {
                case "GuessACard":
                    builder.SetAvailableActions(new List<IGameAction>() { new GuessCardAction() });
                    builder.SetInitialGameState(new GameState());
                    builder.SetVictoryConditions(new List<IGameCondition>() { new DidGuessACard() });
                    builder.SetGameStopConditions(new List<IGameCondition>() { new DidTurnsExpire() });
                    builder.SetMaxTurns(5);
                    builder.SetCardComparisonStrategy(new StrictCardComparisonStrategy());
                    break;
                case "Blackjack":
                    builder.SetAvailableActions(new List<IGameAction>() { new BlackjackDrawAction(), new BlackjackPassAction() });
                    builder.SetInitialGameState(new GameState());
                    builder.SetVictoryConditions(new List<IGameCondition>() { new BlackjackVictory() });
                    builder.SetGameStopConditions(new List<IGameCondition>() { new BlackjackGameStop() });
                    builder.SetMaxTurns(20);
                    builder.SetCardComparisonStrategy(null);
                    break;
            }
        }

        public bool ShouldReactTo(string outerCommandName)
        {
            return _identifier.ToLower() == outerCommandName.ToLower();
        }


        private static IGameImplementation SelectGameImplementation(string parameters)
        {
            IGameImplementation gameImpl = null;
            if (parameters.ToLower() == "GuessACard".ToLower())
            {
                gameImpl = new GuessACardGame();
            }

            if (parameters.ToLower() == "Blackjack".ToLower())
            {
                gameImpl = new BlackjackGame();
            }

            if (gameImpl == null) throw new ArgumentException("Either the game is not registered in factory or game identifier has a typo. Got: " + parameters);

            return gameImpl;
        }

    }
}
