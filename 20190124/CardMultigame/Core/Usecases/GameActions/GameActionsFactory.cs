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
            List<IGameAction> orders = new List<IGameAction>();

            foreach (var action in actionsToPerform.Split(','))
            {
                orders.Add(CreateAction(action.Trim()));
            }

            return orders;
        }

        private IGameAction CreateAction(string action)
        {
            switch (action)
            {
                case "drawSingleCard":
                    return new DrawSingleCardAction();
                case "addQH":
                    return new AddQueenOfHeartsToDeck();
                case "add10cOrDraw":
                    return new Add10COrDrawACard();
                default:
                    return null;
            }
        }
    }
}
