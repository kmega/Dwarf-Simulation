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
            List<IGameAction> gameActionsFromOrders = new List<IGameAction>();
            var splittedOrders = actionsToPerform.Split(", ", StringSplitOptions.None);
            foreach(var order in splittedOrders)
            {
                gameActionsFromOrders.Add(BuildSingleOrder(order));
            }
            return gameActionsFromOrders;
        }

        private IGameAction BuildSingleOrder(string order)
        {
            switch(order)
            {
                case "drawSingleCard":
                    return new DrawSingleCardAction();
                case "add10cOrDraw":
                    return new Add10COrDrawACard();
                case "addQH":
                    return new AddQueenOfHeartsToDeck();
                default:
                    return null;
            }
        }
    }
}
