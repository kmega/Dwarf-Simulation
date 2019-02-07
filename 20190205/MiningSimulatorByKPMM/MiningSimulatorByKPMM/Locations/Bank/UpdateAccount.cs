using MiningSimulatorByKPMM.DwarfsTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Bank
{
    public static class UpdateAccount
    {
        public static void MoveDailyPaymentToAccount(List<Dwarf> dwarves)
        {
            foreach (var dwarf in dwarves)
            {
                dwarf.BankAccount.CalculateOverallAccount();
            }

        }

    }
}
