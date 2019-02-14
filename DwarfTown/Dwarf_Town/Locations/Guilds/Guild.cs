using Dwarf_Town.Enums;
using Dwarf_Town.Interfaces;
using Dwarf_Town.Locations.Guild.OreValue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dwarf_Town.Locations.Guild
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

        public void PaymentForDwarves (List<ISell> dwarvesVisitGuild)
        {
            foreach (var dwarf in dwarvesVisitGuild)
            {
                foreach (var ore in dwarf.ShowBackpack())
                {
                    decimal value = ReturnOreValue(ore);
                    decimal provision = Math.Round((value * 0.25m),2);
                    _account += provision;
                    decimal payment = Math.Round((value - provision),2);
                    dwarf.ReceivedMoney(payment);
                }
                dwarf.ShowBackpack().Clear();
            }
        }

        public decimal ShowTresure()
        {
            return _account;
        }
    



    }
}
