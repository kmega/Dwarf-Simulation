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
            List<IGameAction> Actions = new List<IGameAction>();
            Actions.Add(new GuessCardAction());
            return Actions;
            
        }

        public List<IGameCondition> GameStopConditions()
        {
            List<IGameCondition> GameStopConditions = new List<IGameCondition>();
            GameStopConditions.Add(new DidTurnsExpire());
            return GameStopConditions;

        }

        public List<IGameCondition> VictoryConditions()
        {
            List<IGameCondition> VictoryConditions = new List<IGameCondition>();
            VictoryConditions.Add(new DidGuessACard());
            return VictoryConditions;
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
        }
    }
}
