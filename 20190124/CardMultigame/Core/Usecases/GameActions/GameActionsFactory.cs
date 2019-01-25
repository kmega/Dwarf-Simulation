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
            //throw new NotImplementedException("Implement this for T204 Factorize me");
            List<IGameAction> gameActions = new List<IGameAction>();
            List<string> orders = actionsToPerform.Split(",").ToList();

            orders.ForEach(order =>
            {
                switch(order.Trim()) // fucking Trim() remember to not forget about it
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
            });

            return gameActions;
        }
    }
}
