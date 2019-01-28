using Core.Entities.Games.Guessing;
using System.Collections.Generic;
using Core.Entities.Decks;
using Core.Usecases.GameActions;
using Core.Usecases.GameConditions;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;

namespace Core.Entities.Games
{
    public class OczkoGame : IGameImplementation
    {
        public CardDeck CardDeck()
        {
            return new CreateCardDeck().Simple9ToKWith4Colours();
        }

        public List<IGameAction> AvailableActions()
        {
            return new List<IGameAction>() { new DrawTurnAction() };
        }

        public List<IGameCondition> GameStopConditions()
        {
            return new List<IGameCondition>() { new DidTurnsExpire() };
        }

        public List<IGameCondition> VictoryConditions()
        {
            return new List<IGameCondition>() { new DidPassInTime() };
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
            return "Oczko Game!";
        }

        public ICardComparisonStrategy CardComparisonStrategy()
        {
            return new RankCardComparisonStrategy();
        }
    }
}
