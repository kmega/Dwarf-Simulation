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
            List<IGameAction> actions = new List<IGameAction>();
            actions.Add(new GuessCardAction());
            return actions;
        }

        public List<IGameCondition> GameStopConditions()
        {
            List<IGameCondition> gameStopConditions = new List<IGameCondition>();
            gameStopConditions.Add(new DidTurnsExpire());
            return gameStopConditions;
        }

        public List<IGameCondition> VictoryConditions()
        {
            List<IGameCondition> victoryConditions = new List<IGameCondition>();
            victoryConditions.Add(new DidGuessACard());
            return victoryConditions;
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
