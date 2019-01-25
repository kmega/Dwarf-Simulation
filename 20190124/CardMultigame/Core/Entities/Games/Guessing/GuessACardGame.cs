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
            List<IGameAction> gameActions = new List<IGameAction>();
            gameActions.Add(new GuessCardAction());
            return gameActions;
            //throw new NotImplementedException("Implement this for T209 GuessACardGame was a strategy!");
        }

        public List<IGameCondition> GameStopConditions()
        {
            List<IGameCondition> gameActions = new List<IGameCondition>();
            gameActions.Add(new DidTurnsExpire());
            return gameActions;
        }

        public List<IGameCondition> VictoryConditions()
        {
            List<IGameCondition> gameActions = new List<IGameCondition>();
            gameActions.Add(new DidGuessACard());
            return gameActions;
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
