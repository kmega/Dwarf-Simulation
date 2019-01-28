using Core.Entities.Decks;
using Core.Entities.Games.Guessing;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Games.BlackJack
{
    public class BlackJackGame : IGameImplementation
    {
        public List<IGameAction> AvailableActions()
        {
            return new List<IGameAction>()
            {
                new DrawSingleCardAction(),
                new SumScoreAction(),
                new PassTurn()
            };
        }

        public ICardComparisonStrategy CardComparisonStrategy()
        {
            return new CreateCardComparisonStrategy().None();
        }

        public CardDeck CardDeck()
        {
            return new CreateCardDeck().Simple9ToKWith4Colours();
        }

        public List<IGameCondition> GameStopConditions()
        {
            return new List<IGameCondition>()
            {
                new IsPlayerScoreGreaterThan21(),
                new DidPlayerPassedToEarly()
            };
        }

        public GameState InitialGameState()
        {
            return new GameState()
            {
                { GameStateKeys.MaxTurns, 20 }
            };
        }

        public string Title()
        {
            return "BlackJack";
        }

        public List<IGameCondition> VictoryConditions()
        {
            return new List<IGameCondition>()
            {
                new DidPlayerPassedInGoodMoment()
            };
        }
    }
}
