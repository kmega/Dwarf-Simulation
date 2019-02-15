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
        private Dictionary<MineralType, decimal> _oreValueRegister;
        public IOutputWriter Presenter;

        public Guild(Dictionary<MineralType, IOreValue> oresOnMarket, Dictionary<MineralType, decimal> oreValueRegister, IOutputWriter presenter )
        {
            _account = 0;
            _oresOnMarket = oresOnMarket;
            _oreValueRegister = oreValueRegister;
            Presenter = presenter;
            
        }

        public decimal ReturnOreValue(MineralType mineraltype)
        {
            return _oresOnMarket[mineraltype].GenerateOreValue();
        }

        public void PaymentForDwarves (List<ISell> dwarvesVisitGuild)
        {
            List<string> message = new List<string>();
            foreach (var dwarf in dwarvesVisitGuild)
            {
                foreach (var ore in dwarf.ShowBackpack())
                {
                    decimal value = ReturnOreValue(ore);
                    _oreValueRegister[ore] += value;
                    decimal provision = Math.Round((value * 0.25m),2);
                    _account += provision;
                    decimal payment = Math.Round((value - provision),2);
                    dwarf.ReceivedMoney(payment);
                  Presenter.WriteLine($"Dwarf exchange {ore} for {payment} gp and guild take {provision} gp provision");
                }
                dwarf.ShowBackpack().Clear();
            }
           
        }

        public decimal ShowTresure()
        {
            return _account;
        }

        public Dictionary<MineralType, decimal> ShowGuildRegister()
        {
            return _oreValueRegister;
        }

    }
}
