using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Mine;
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
            MineSupervisor mineSupervisor = new MineSupervisor();
            Guild guild = new Guild();
            Canteen canteen = new Canteen();
            canteen.FoodRations = 200;
            _currentSimulationState.Dwarves = hospital.BuildInitialSocietyMembers();
            for (int i = 0; i < 30; i++)
            {
                //Hospital.TryToBorn(currentSimulationState) -> Dwarf or Null;
                var dwarf = hospital.TryToCreateDwarf();
                if (dwarf != null)
                {
                    _currentSimulationState.Dwarves.Add(dwarf);
                }

                //Mine.Work(List<Backpack>,List<dwarfType>) -> aktualizacja Backpack;
                var dwarfBackpacks = _currentSimulationState.Dwarves.Select(p => p.Backpack).ToList();
                var dwarfTypes = _currentSimulationState.Dwarves.Select(p => p.DwarfType).ToList();
                var dwarfLifeStatus = _currentSimulationState.Dwarves.Select(p => p.IsAlive).ToList();
                mineSupervisor.Work(dwarfBackpacks, dwarfTypes, dwarfLifeStatus);

                //Guild.PayWorkers(List<BankAccount> bankAccounts, backpacks);
                guild.DwarvesVisitGuild(_currentSimulationState.Dwarves);

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
                UpdateAccount.MoveDailyPaymentToAccount(_currentSimulationState.Dwarves);
                //
            }
        }
    }
}