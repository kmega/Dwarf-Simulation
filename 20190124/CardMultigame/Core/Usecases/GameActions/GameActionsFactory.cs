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
            List<IGameAction> actions = new List<IGameAction>();

            string[] actionsToPerformArray = actionsToPerform.Split(',');

            foreach (var action in actionsToPerformArray)
            {
                actions.Add(Create(action.Trim()));
            }

            return actions;
            //throw new NotImplementedException("Implement this for T204 Factorize me");
        }

        private IGameAction Create(string selector)
        {
            switch(selector)
            {
                case "drawSingleCard":
                    return new DrawSingleCardAction();
                case "addQH":
                    return new AddQueenOfHeartsToDeck();
                case "add10cOrDraw":
                    return new Add10COrDrawACard();
            }
            return null;
        }
    }
}