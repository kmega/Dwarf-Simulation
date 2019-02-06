using MiningSimulatorByKPMM.DwarfsTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState currentSimulationState;

        public SimulationEngine()
        {
            currentSimulationState = new SimulationState();
        }

        public void Start()
        {
            for (int i = 0; i < 30; i++)
            {
                //Hospital.TryToBorn(currentSimulationState) -> Dwarf or Null;
                //Mine.Work(List<Backpack>,List<dwarfType>) -> aktualizacja Backpack;
                //Guild.PayWorkers(List<BankAccount> bankAccounts, backpacks);
                // int value;
                // Bank.PutIn(bankAccount, value);
                // Bank.Putin(GuildAccount, valuezarobionie25%);

                //Canteen(numberOfWorkersToday);
                //Shop.BuyStaff(List<BankAccount> bankAccounts, List<DwarfType> dwarftypes);
                // int ostatniaWpłata = Bank.GetLastInput(bankaccount);
                //int paragon = ostatniawplata /2
                // int result = Bank.PayTax(paragon);
                // Bank.Putin(shopBankAccount, result);
                //Bank.SumDay(List<bankAccount>);
                //Bankaccount -> overallMoney, lastInput
                //
            }
        }
    }
}