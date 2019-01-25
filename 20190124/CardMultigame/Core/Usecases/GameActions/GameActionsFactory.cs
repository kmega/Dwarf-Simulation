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
            List<IGameAction> l = new List<IGameAction>();
            string[] actions = (actionsToPerform).Split(',');
            foreach (string a1 in actions)
            {
                string a = a1.Trim();
                IGameAction o = transform(a);
                l.Add(o);
            }


            return l;
        }

        private IGameAction transform(string a)
        {
            if (a == "drawSingleCard")
                return new DrawSingleCardAction();
            else if (a == "addQH")
                return new AddQueenOfHeartsToDeck();
            else if (a == "add10cOrDraw")
                return new Add10COrDrawACard();
            else
                throw new Exception();
        

        }
    }
}
