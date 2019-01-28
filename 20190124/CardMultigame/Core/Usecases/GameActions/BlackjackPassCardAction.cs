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

namespace Core.Usecases.GameActions
{
    public class BlackjackPassCardAction : IGameAction
    {
        string _identifier = "Pass";

        public void ChangeGameState(GameState currentGameState, PlayedGameRules rules, string orderParams)
        {
            currentGameState["Pass"] = "true";
        }

        public bool ShouldReactTo(string orderName)
        {
            return _identifier.ToLower() == orderName.ToLower();
        }
    }
}
