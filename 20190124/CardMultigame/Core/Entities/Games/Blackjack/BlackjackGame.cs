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
    public class BlackjackGame : IGameImplementation
    {
        public CardDeck CardDeck()
        {
            return new CardDeckFactory().Simple9ToKWith4Colours();
        }

        public List<IGameAction> AvailableActions()
        {
            return new List<IGameAction>()
            {
                new BlackjackDrawCardAction(),
                new BlackjackPassCardAction() 
            };
        }

        public List<IGameCondition> GameStopConditions()
        {
            return new List<IGameCondition>() 
            { 
                new DidTurnsExpire() 
            };
        }

        public List<IGameCondition> VictoryConditions()
        {
            return new List<IGameCondition>()
            {
                new SumOfPoints()
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
            return "Blackjack!";
        }

        public ICardComparisonStrategy CardComparisonStrategy()
        {
            return null;
        }
    }
}
