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
			List<IGameAction> ListOfActions = new List<IGameAction>();
			var actions = actionsToPerform.Split(",", StringSplitOptions.None);
			foreach(var action in actions)
			{
				ListOfActions.Add(SingleAction(action.Trim()));
			}
			return ListOfActions;
        }

		public IGameAction SingleAction(string action)
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
