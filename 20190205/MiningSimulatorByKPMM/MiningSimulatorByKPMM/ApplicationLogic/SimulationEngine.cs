using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Market;
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
            Market market = new Market();
            Canteen canteen = new Canteen();
            GeneralBank generalBank = new GeneralBank();
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
                mineSupervisor.Work(ref dwarfBackpacks, dwarfTypes, ref dwarfLifeStatus);

                for (int j = 0; j < _currentSimulationState.Dwarves.Count; j++)
                {
                    _currentSimulationState.Dwarves[j].IsAlive = dwarfLifeStatus[j];
                }

                for (int k = 0; k < _currentSimulationState.Dwarves.Count; k++)
                {
                    _currentSimulationState.Dwarves[k].Backpack = dwarfBackpacks[k];
                }

                //Guild.PayWorkers(List<BankAccount> bankAccounts, backpacks);
                guild.DwarvesVisitGuild(_currentSimulationState.Dwarves);

                //Market.BuyStaff(List<BankAccount> bankAccounts, List<DwarfType> dwarftypes);

                // int ostatniaWpłata = Bank.GetLastInput(bankaccount);
                //int paragon = ostatniawplata /2
                // int result = Bank.PayTax(paragon);
                // Bank.Putin(shopBankAccount, result);
                //Bank.SumDay(List<bankAccount>);
                //Bankaccount -> overallMoney, lastInput

                //Canteen(numberOfWorkersToday);
                canteen.GiveFoodRations(_currentSimulationState.Dwarves.Count);
                canteen.OrderFoodRations();

                UpdateAccount.MoveDailyPaymentToAccount(_currentSimulationState.Dwarves);
                //
            }
        }
    }
}