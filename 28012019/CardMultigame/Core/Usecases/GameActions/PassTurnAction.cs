using Core.Containers.GameRules;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class PassTurnAction : IGameAction
    {
        string _identifier = "Pass";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            CardDeck deck = QueryGameState.ExtractCardDeck(currentGameState);
            Card card = deck.DrawRandomCard();

            int pointsBeforePass = (int)currentGameState[GameStateKeys.Points];

            QueryGameState.AddPoints(currentGameState, card);
            int pointsAfterPass = (int)currentGameState[GameStateKeys.Points];

            if (pointsBeforePass + (pointsAfterPass - pointsBeforePass) > 21)
            {
                ModifyGameState.DeclareGameToBeWon(currentGameState);
            }
            else
            {
                ModifyGameState.DeclareGameToBeLost(currentGameState);
            }

            ModifyGameState.AddTurn(currentGameState);
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
