using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usecases.GameActions;
using Core.Entities.Games.Guessing;
using Core.Entities.Games;

namespace Core.Containers.GameRules.CreationCommands
{
    public class SelectGame : ICreateGameRulesCommand
    {
        private string _identifier = "Play";

        public void ChangeGameRuleset(GameManagerInternalsBuilder builder, string parameters)
        {
           IGameImplementation game=  SelectGameImplementation(parameters);
            builder.SetAvailableActions(game.AvailableActions());
            builder.SetCardComparisonStrategy(game.CardComparisonStrategy());
            builder.SetDeck(game.CardDeck());
            builder.SetGameStopConditions(game.GameStopConditions());
            builder.SetInitialGameState(game.InitialGameState());
            builder.SetName(game.Title());
            builder.SetVictoryConditions(game.VictoryConditions());

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
