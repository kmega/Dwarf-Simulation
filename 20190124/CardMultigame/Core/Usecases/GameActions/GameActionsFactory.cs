using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Usecases.GameActions
{
    public class GameActionsFactory
    {
        public List<IGameAction> HavingOrders(string actionsToPerform)
        {

            

            var actions = actionsToPerform.Split(',');

            List<IGameAction> workingActions = new List<IGameAction>();

            foreach (var action in actions)
            {
                if (action.Trim() == "drawSingleCard") workingActions.Add(new DrawSingleCardAction());
                if (action.Trim() == "addQH") workingActions.Add(new AddQueenOfHeartsToDeck());
                if (action.Trim() == "add10cOrDraw") workingActions.Add(new Add10COrDrawACard());
            }

            return workingActions;

        }
    }
}
