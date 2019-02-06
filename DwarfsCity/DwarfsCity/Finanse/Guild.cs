using DwarfsCity.DwarfContener;
using System.Collections.Generic;

namespace DwarfsCity
{
    public class Guild
    {
        private decimal _guildMoney = 0;

        public void GetMoneyFromDwarfs(List<Dwarf> dwarfs)
        {
            foreach (var dwarfMoney in dwarfs)
            {
                _guildMoney += dwarfMoney.Backpack.Moneys;
            }
        }

        public decimal GetGuildMoney()
        {
            return _guildMoney;
        }

        public bool SpendGiuldMoney(decimal amountOfMoneyToSpend)
        {
            if (_guildMoney < amountOfMoneyToSpend)
                return false;
            else
            {
                _guildMoney -= amountOfMoneyToSpend;
                return true;
            }
                
        }
    }
}