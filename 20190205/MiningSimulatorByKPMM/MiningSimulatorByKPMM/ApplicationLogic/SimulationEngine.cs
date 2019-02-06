using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using System.Linq;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState _currentSimulationState;

        public SimulationEngine()
        {
            _currentSimulationState = new SimulationState();
        }

        public void Start()
        {
            Hospital hospital = new Hospital();
            Guild guild = new Guild();
            Canteen canteen = new Canteen();
            for (int i = 0; i < 30; i++)
            {
                //Hospital.TryToBorn(currentSimulationState) -> Dwarf or Null;
                var dwarf = hospital.TryToCreateDwarf();
                if (dwarf != null)
                {
                    _currentSimulationState.Dwarves.Add(dwarf);
                }

                //Mine.Work(List<Backpack>,List<dwarfType>) -> aktualizacja Backpack;
                var backpacks = _currentSimulationState.Dwarves.Select(p => p.Backpack).ToList();
                var dwarfTypes = _currentSimulationState.Dwarves.Select(p => p.DwarfType).ToList();

                //Guild.PayWorkers(List<BankAccount> bankAccounts, backpacks);

                // int value;
                // Bank.PutIn(bankAccount, value);
                // Bank.Putin(GuildAccount, valuezarobionie25%);

                //Canteen(numberOfWorkersToday);
                canteen.GiveFoodRations(_currentSimulationState.Dwarves.Count);
                canteen.OrderFoodRations();

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