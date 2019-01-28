using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Usecases.InfluenceState;
using Core.Entities.Cards;

namespace Core.Usecases.GameConditions
{
    /// <summary>
    /// If there exists a 'Guess' key in the gameState AND the value is true, 
    /// declare game has been won.
    /// </summary>
    public class SumOfPoints : IGameCondition
    {
        public void CheckAndUpdate(GameState currentGameState)
        {
            if (currentGameState["Pass"] as bool? == true)
            {
                Card nextCard = QueryGameState.ExtractCardDeck(currentGameState).DrawRandomCard();

                switch (nextCard.Rank())
                {
                    case "9":
                        currentGameState["NextCardValue"] = 2;
                        break;
                    case "10":
                        currentGameState["NextCardValue"] = 3;
                        break;
                    case "J":
                        currentGameState["NextCardValue"] = 4;
                        break;
                    case "Q":
                        currentGameState["NextCardValue"] = 5;
                        break;
                    case "K":
                        currentGameState["NextCardValue"] = 6;
                        break;
                    default:
                        break;
                }

                int points = (int)currentGameState["Points"];
                points += (int)currentGameState["NextCardValue"];

                if (points > 21)
                    ModifyGameState.DeclareGameToBeLost(currentGameState);
                else
                    ModifyGameState.DeclareGameToBeWon(currentGameState);
            }

            if (currentGameState["Points"] as int? > 21)
            {
                ModifyGameState.DeclareGameToBeLost(currentGameState);
            }
        }
    }
}
