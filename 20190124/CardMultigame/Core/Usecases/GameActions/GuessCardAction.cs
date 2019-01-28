using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.GameStates;
using Core.Entities.Cards;
using Core.Containers.GameRules;
using Core.Usecases.CardComparison;
using Core.Usecases.InfluenceState;
using Core.Entities.Decks;
using Core.Technical.Parsers;

namespace Core.Usecases.GameActions
{
    public class GuessCardAction : IGameAction
    {
        string _identifier = "Guess";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            var ordersReceived = new SelectedParser().ProperlyParse(orderParams);

            if (currentGameState["Guess"] as bool? == false)
            {

                ModifyGameState.AddTurn(currentGameState);
            };
            
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
