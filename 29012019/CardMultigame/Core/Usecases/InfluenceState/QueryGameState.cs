using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using System;

namespace Core.Usecases.InfluenceState
{
    /// <summary>
    /// STATELESS FOREVER. Queries over a Dictionary ONLY.
    /// Queries do not, ever, change the internal state at all. They are automatically safe.
    /// 
    /// This is a hint of 'Q' in CQS.
    /// </summary>
    public static class QueryGameState
    {
        public static int MaximumTurns(GameState currentState)
        {
            int? currentTurn = currentState[GameStateKeys.MaxTurns] as int?;

            if (currentTurn == null) throw new ArgumentNullException("Current turn cannot be a null");
            else return currentTurn.Value;
        }

        public static bool IsGameWon(GameState currentState)
        {
            return (bool)currentState[GameStateKeys.IsGameWon];
        }

        public static bool IsGameLost(GameState currentState)
        {
            return (bool)currentState[GameStateKeys.IsGameLost];
        }

        public static bool IsGameFinished(GameState currentState)
        {
            return IsGameWon(currentState) || IsGameLost(currentState);
        }

        public static int CurrentTurn(GameState currentState)
        {
            int? currentTurn = currentState[GameStateKeys.CurrentTurn] as int?;

            if (currentTurn == null) throw new ArgumentNullException("Current turn cannot be a null");
            else return currentTurn.Value;
        }

        public static int AmountOfCardsLeft(GameState currentState)
        {
            return ExtractCardDeck(currentState).CardsLeft();
        }

        public static string GameUndergoing(GameState currentState)
        {
            if ((bool)currentState[GameStateKeys.IsGameWon]) return "Victory";
            else if ((bool)currentState[GameStateKeys.IsGameLost]) return "Defeat";
            else return "Undergoing";
        }

        public static CardDeck ExtractCardDeck(GameState currentState)
        {
            return currentState[GameStateKeys.CardDeck] as CardDeck;
        }

        public static int AddPoints(GameState currentState, Card card)
        {
            int addPoints = (int)currentState[GameStateKeys.Points];

            switch (card.Rank())
            {
                case "9":
                    addPoints += 2;
                    break;
                case "10":
                    addPoints += 3;
                    break;
                case "J":
                    addPoints += 4;
                    break;
                case "Q":
                    addPoints += 5;
                    break;
                case "K":
                    addPoints += 6;
                    break;
            }

            currentState[GameStateKeys.Points] = addPoints;

            return (int)currentState[GameStateKeys.Points];
        }

    }
}
