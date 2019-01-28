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
	public class BlackJack : IGameImplementation
	{
		public CardDeck CardDeck()
		{
			return new CardDeckFactory().Simple9ToAWith4Colours();
		}

		public List<IGameAction> AvailableActions()
		{
			return new List<IGameAction> { new GuessCardAction() };
		}

		public List<IGameCondition> GameStopConditions()
		{
			return new List<IGameCondition> { new DidTurnsExpire() };
		}

		public List<IGameCondition> VictoryConditions()
		{
			return new List<IGameCondition> { new DidGuessACard() };
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
			return "Black Jack Bitches!";
		}

		public ICardComparisonStrategy CardComparisonStrategy()
		{
			return new StrictCardComparisonStrategy();
		}
	}
}