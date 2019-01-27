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
            //IGameImplementation gameImplementation = SelectGameImplementation(parameters);

            //builder.SetName(gameImplementation.Title());
            //builder.SetAvailableActions(gameImplementation.AvailableActions());
            //builder.SetVictoryConditions(gameImplementation.VictoryConditions());
            //builder.SetGameStopConditions(gameImplementation.GameStopConditions());
            //builder.SetDeck(gameImplementation.CardDeck());
            //builder.SetInitialGameState(gameImplementation.InitialGameState());
            //builder.SetMaxTurns(5);
            //builder.SetCardComparisonStrategy(gameImplementation.CardComparisonStrategy());

            //switch (parameters)
            //{
            //    case "GuessACard":
            //        builder.SetAvailableActions(new List<IGameAction>() { new GuessCardAction() });
            //        builder.SetInitialGameState(new GameState());
            //        builder.SetVictoryConditions(new List<IGameCondition>() { new DidGuessACard() });
            //        builder.SetGameStopConditions(new List<IGameCondition>() { new DidTurnsExpire() });
            //        builder.SetMaxTurns(5);
            //        builder.SetCardComparisonStrategy(new StrictCardComparisonStrategy());
            //        builder.SetName("");
            //        break;
            //}


            if (parameters.Equals("GuessACard")) 
            {
                builder.SetAvailableActions(new List<IGameAction>() { new GuessCardAction() });
                builder.SetInitialGameState(new GameState());
                builder.SetVictoryConditions(new List<IGameCondition>() { new DidGuessACard() });
                builder.SetGameStopConditions(new List<IGameCondition>() { new DidTurnsExpire() });
                builder.SetMaxTurns(5);
                builder.SetCardComparisonStrategy(new StrictCardComparisonStrategy());
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

            if (gameImpl == null) throw new ArgumentException("Either the game is not registered in factory or game identifier has a typo. Got: " + parameters);

            return gameImpl;
        }

    }
}
