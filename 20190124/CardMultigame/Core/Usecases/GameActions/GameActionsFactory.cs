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
            //throw new NotImplementedException("Implement this for T204 Factorize me");
        }

        private IGameAction BuildSingleOrder(string order)
        {
            throw new NotImplementedException();
        }
    }
}
