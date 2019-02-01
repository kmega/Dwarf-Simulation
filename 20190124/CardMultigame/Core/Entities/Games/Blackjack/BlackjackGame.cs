using Core.Entities.Games.Guessing;
using System.Collections.Generic;
using Core.Entities.Decks;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Entities.Cards;
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
                new BlackjackDrawAction(),
                new BlackjackPassAction()
            };
        }

        public List<IGameCondition> GameStopConditions()
        {
            return new List<IGameCondition>()
            {
                new BlackjackVictory()
            };
        }

        public List<IGameCondition> VictoryConditions()
        {
            return new List<IGameCondition>()
            {
                new BlackjackGameStop()
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
