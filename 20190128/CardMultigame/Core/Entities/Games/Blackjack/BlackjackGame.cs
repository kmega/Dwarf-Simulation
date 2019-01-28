using System;
using System.Collections.Generic;
using Core.Entities.Decks;
using Core.Entities.Games.Guessing;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;

namespace Core.Entities.Games
{
    public class BlackjackGame : IGameImplementation
    {
        public int CardSum { get; set; }

        public CardDeck CardDeck()
        {
            return new CreateCardDeck().Simple9ToAWith4Colours();
        }

        public List<IGameAction> AvailableActions()
        {
            return new List<IGameAction>() { new DrawSingleCardForBlackjack(), new PassBlackjack()};
        }

        public List<IGameCondition> GameStopConditions()
        {
            return new List<IGameCondition>() { new DidTurnsExpire() };
        }

        public List<IGameCondition> VictoryConditions()
        {
            return new List<IGameCondition>() { new CardsValueIsEqual21() };
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
            return new BlackjackComparison();
        }
    }
}