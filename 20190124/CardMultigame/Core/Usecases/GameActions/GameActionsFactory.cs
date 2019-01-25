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
            //string actionsToPerform = "drawSingleCard, drawSingleCard, drawSingleCard, addQH, addQH, " +
            //"add10cOrDraw, add10cOrDraw";
            // string.Split(','); string.Trim(); List.Add; foreach;

            List<IGameAction> actions = new List<IGameAction>();

            string[] actionsToDo = actionsToPerform.Split(',');

            foreach (var action in actionsToDo)
            {

                if (action.Trim() == "drawSingleCard")
                    actions.Add(new DrawSingleCardAction());

                if (action.Trim() == "addQH")
                    actions.Add(new AddQueenOfHeartsToDeck());

                if (action.Trim() == "add10cOrDraw")
                    actions.Add(new Add10COrDrawACard());
            }

            return actions;

        }
    }
}
