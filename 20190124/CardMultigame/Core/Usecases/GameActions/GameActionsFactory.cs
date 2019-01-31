using Core.Entities.GameStates;
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
            List<IGameAction> actionsToPrepare = new List<IGameAction>();

            string[] singleActions = actionsToPerform.Split(",");
            
            foreach(var single in singleActions)
            {
                IGameAction action = ActionFromString(single.Trim());
                actionsToPrepare.Add(action);
            }

            return actionsToPrepare;
            

        }

        private IGameAction ActionFromString(string action)
        {
    
            switch (action)
            {
                case "drawSingleCard":
                    return new DrawSingleCardAction();
                case "addQH":
                    return new AddQueenOfHeartsToDeck();
                case "add10cOrDraw":
                    return new Add10COrDrawACard();
                case "draw_bj":
                    return new Draw_BlackJack();
                case "pass_bj":
                    return new Pass_BlackJack();
                default:
                    return null;
            }
            
        }
    }
}
