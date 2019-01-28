using Core.Entities.GameStates;
using Core.Usecases.GameConditions;
using Core.Usecases.InfluenceState;

namespace Core.Entities.Games.BlackJack
{
    public class IsPlayerScoreGreaterThan21 : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            int? finalScore = currentGameState[GameStateKeys.BlackJackScore] as int?;
            if(finalScore > 21)
            {
                ModifyGameState.DeclareGameToBeLost(currentGameState);
            }
        }
    }
}