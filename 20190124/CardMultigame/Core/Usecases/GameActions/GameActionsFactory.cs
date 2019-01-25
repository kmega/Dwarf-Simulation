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
            List<IGameAction> gameActions = new List<IGameAction>();
            string[] spllitedOrders = actionsToPerform.Split(',');
            foreach(string order in spllitedOrders)
            {
                switch(order.Trim())
                {
                    case "drawSingleCard":
                        gameActions.Add(new DrawSingleCardAction());
                        break;
                    case "addQH":
                        gameActions.Add(new AddQueenOfHeartsToDeck());
                        break;
                    case "add10cOrDraw":
                        gameActions.Add(new Add10COrDrawACard());
                        break;
                }
            }
            return gameActions;
            
        }
    }
}
