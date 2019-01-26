﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Usecases.GameActions;
using Core.Entities.Games.Guessing;
using Core.Entities.Games;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.GameConditions;

namespace Core.Containers.GameRules.CreationCommands
{
    public class SelectGame : ICreateGameRulesCommand
    {
        private string _identifier = "Play";

        public void ChangeGameRuleset(GameManagerInternalsBuilder builder, string parameters)
        {
            if(parameters.Equals("GuessACard"))
            {
                builder.SetInitialGameState(new GameState());
                builder.SetCardComparisonStrategy(new StrictCardComparisonStrategy());
                builder.SetVictoryConditions(new List<IGameCondition> { new DidGuessACard() });
                builder.SetGameStopConditions(new List<IGameCondition> { new DidTurnsExpire() });
                builder.SetMaxTurns(5);
                builder.SetAvailableActions(new List<IGameAction> { new GuessCardAction() });
            }

            //throw new NotImplementedException("Implement this for T210 BuilderRevealsItself");
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
