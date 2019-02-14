using System;
using System.Collections.Generic;
using System.Text;
using DwarfLifeSimulation.Dwarves;
using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Locations.Banks;

namespace DwarfLifeSimulation.Locations.Guilds
{
    public class Guild
    {
		private int _bankAccountId;

		public Guild()
		{
			_bankAccountId = Bank.Instance.CreateAccount();
		}

        public void ExchangeResource(IEnumerable<IExchange> workers)
        {
            throw new NotImplementedException();
        }
    }
}
