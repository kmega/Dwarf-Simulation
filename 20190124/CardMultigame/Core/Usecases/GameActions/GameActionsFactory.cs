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
            string[] tab = actionsToPerform.Split(',');
            for (int i = 0; i < tab.Length; i++)
            {
                IGameAction a = CreateSingle(tab[i].Trim());

                gameActions.Add(a);
            }

            return gameActions;
        }

        private IGameAction CreateSingle(string selector)
        {
            if (selector == "drawSingleCard")
            {
                return new DrawSingleCardAction();
            }
            if (selector == "add10cOrDraw")
            {
                return new Add10COrDrawACard();
            }
            if (selector == "addQH")
            {
                return new AddQueenOfHeartsToDeck();
            }
            else
                return null;
        }
    }
}
