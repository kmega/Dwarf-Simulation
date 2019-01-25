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
           
            string[] actions = actionsToPerform.Split(",");
            

            foreach (var item in actions)
            {
                
                switch (item.Trim())
                {
                    case "drawSingleCard":
                        orders.Add(new DrawSingleCardAction());
                        break;

                    case "addQH":
                        orders.Add(new AddQueenOfHeartsToDeck());
                        break;

                    case "add10cOrDraw":
                        orders.Add(new Add10COrDrawACard());
                        break;
                    default:
                        break;
                }
            }
            return orders;

        }
    }
}
