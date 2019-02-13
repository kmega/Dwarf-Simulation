using Dwarf.Town.Enums;
using Dwarf.Town.Interfaces;
using Dwarf.Town.Locations.Guild.OreValue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf.Town.Locations.Guild
{
    public class Guild
    {
        private decimal _account;
        private Dictionary <MineralType, IOreValue> _oresOnMarket;

        public Guild(Dictionary<MineralType, IOreValue> oresOnMarket)
        {
            _account = 0;
            _oresOnMarket = oresOnMarket;
        }

        public decimal ReturnOreValue(MineralType mineraltype)
        {
            return _oresOnMarket[mineraltype].GenerateOreValue();
        }

        public void PaymentForDwarves (List<ISell> dwarvesSellStrategy)
        {
            foreach (var dwarf in dwarvesSellStrategy)
            {

                foreach (var ore in dwarf.ShowBackpack())
                {
                    decimal value = ReturnOreValue(ore);
                    decimal provision = Math.Round((value * 0.23m),2);
                    decimal payment = Math.Round((value - provision),2);
                    _account += provision;
                    dwarf.ReceivedMoney(payment);
                }
                dwarf.ShowBackpack().Clear();
            }
        }
    



    }
}
