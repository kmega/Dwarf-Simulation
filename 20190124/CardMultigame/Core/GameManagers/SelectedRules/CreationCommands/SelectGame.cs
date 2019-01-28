using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usecases.GameActions;
using Core.Entities.Games.Guessing;
using Core.Entities.Games;
using Core.Usecases.CardComparison;
using Core.Usecases.GameConditions;

namespace Core.Containers.GameRules.CreationCommands
{
    public class SelectGame : ICreateGameRulesCommand
    {
        private string _identifier = "Play";

        public void ChangeGameRuleset(GameManagerInternalsBuilder builder, string parameters)
        {
            if (parameters == "GuessACard")
            {
                builder.SetCardComparisonStrategy(new StrictCardComparisonStrategy());
                builder.SetAvailableActions(new List<IGameAction>() { new GuessCardAction() });
                builder.SetGameStopConditions(new List<IGameCondition>() { new DidTurnsExpire() });
                builder.SetVictoryConditions(new List<IGameCondition>() { new DidGuessACard() });
            }

            else if ( parameters == "eye")
            {
                builder.SetCardComparisonStrategy(new PointsCardComparsionStrategy());
                builder.SetAvailableActions(new List<IGameAction>() { new DrawSingleCardAction() });
                builder.SetGameStopConditions(new List<IGameCondition>() { new IsItMoreThan21() });
                builder.SetVictoryConditions(new List<IGameCondition>() { new IsItMoreThan21() });
            }
            builder.SetName(parameters);
            
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

            if (gameImpl == null) throw new ArgumentException("Either the game is not registered in factory or game identifier has a typo. Got: " + parameters);

            return gameImpl;
        }

    }
}
