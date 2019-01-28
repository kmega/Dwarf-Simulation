using Core.Containers.GameRules;
using Core.Entities.Cards;
using Core.Entities.Decks;
using Core.Entities.GameStates;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;

namespace Core.Usecases.GameActions
{
    public class DrawTurnAction : IGameAction
    {
        string _identifier = "Draw";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            CardDeck deck = QueryGameState.ExtractCardDeck(currentGameState);
            Card card = deck.DrawRandomCard();

            QueryGameState.AddPoints(currentGameState, card);
            int points = (int)currentGameState[GameStateKeys.Points];

            if (points > 21)
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
