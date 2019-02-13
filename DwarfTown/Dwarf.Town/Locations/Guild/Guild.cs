using Dwarf.Town.Enums;
using Dwarf.Town.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf.Town.Locations.Guild
{
    public class Guild
    {
        private decimal _account;
        private Dictionary <MineralType, IChance> _oresOnMarket;

        public Guild(Dictionary<MineralType, IChance> oresOnMarket)
        {
            _account = 0;
            _oresOnMarket = oresOnMarket;
        }

        public decimal ReturnOreValue(MineralType mineraltype)
        {
            return 0;
            //return _oresOnMarket[mineraltype].
        }

        public voidPaymentForDwarves (List<ISell> dwarvesSellStrategy)
        {

        }
    



    }
}
