using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Bank
    {
        internal void TransferMoneyToAcconunt(List<Dwarf> dwarves)
        {
            foreach (var dwarf in dwarves)
            {
                dwarf.Account = dwarf.Wallet;
                dwarf.Wallet = 0.0m;
            }
        }
    }
}
