using Core.Entities.Decks;
using Core.Entities.Games.Guessing;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Games.Oczko
{
    public class BlackJackGame : IGameImplementation

    {
        public List<IGameAction> AvailableActions()
        {
            return new List<IGameAction>() { new BlackJackDraw(), new BlackJackPass() };
        }

        public ICardComparisonStrategy CardComparisonStrategy()
        {
            return null;
        }

        public CardDeck CardDeck()
        {
            return new CreateCardDeck().Simple9ToAWith4Colours();
        }

        public List<IGameCondition> GameStopConditions()
        {
            return new List<IGameCondition>() { new BlackJackDidScore21OrHigher(), new BlackJackDidPass() };
        }

        public GameState InitialGameState()
        {
            return new GameState()
            {
                {"Points", 0 }
            };
        }

        public string Title()
        {
            return "Black Jack";
        }

        public List<IGameCondition> VictoryConditions()
        {
            return new List<IGameCondition>() { new BlackJackDidScore21(), new BlackJackDidNextMoveGiveMoreThan21()};
        }
    }
}
