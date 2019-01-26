using Core.Entities.Games.Guessing;
using System.Collections.Generic;
using Core.Entities.Decks;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using System;

namespace Core.Entities.Games
{
    public class GuessACardGame : IGameImplementation
    {
        public CardDeck CardDeck()
        {
            return new CardDeckFactory().Simple9ToAWith4Colours();
        }

        public List<IGameAction> AvailableActions()
        {
            List<IGameAction> actions = new List<IGameAction>
            {
                new GuessCardAction()
            };

            return actions;
            //throw new NotImplementedException("Implement this for T209 GuessACardGame was a strategy!");
        }

        public List<IGameCondition> GameStopConditions()
        {
            List<IGameCondition> conditions = new List<IGameCondition>
            {
                new DidTurnsExpire()
            };

            return conditions;
            //throw new NotImplementedException("Implement this for T209 GuessACardGame was a strategy!");
        }

        public List<IGameCondition> VictoryConditions()
        {
            List<IGameCondition> conditions = new List<IGameCondition>
            {
                new DidGuessACard()
            };

            return conditions;
            //throw new NotImplementedException("Implement this for T209 GuessACardGame was a strategy!");
        }

        public GameState InitialGameState()
        {
            return new GameState()
            {
                { GameStateKeys.MaxTurns, 5 }
            };
        }

        public string Title()
        {
            return "Guess a Card!";
        }

        public ICardComparisonStrategy CardComparisonStrategy()
        {
            return new StrictCardComparisonStrategy();
            //throw new NotImplementedException("Implement this for T108 Strategy for the future");
        }
    }
}
