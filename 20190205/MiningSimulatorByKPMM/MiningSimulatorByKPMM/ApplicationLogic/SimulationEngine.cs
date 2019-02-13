using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.Reports;
using System.Linq;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState _currentSimulationState;
        private Hospital hospital;
        private MineSupervisor mineSupervisor;
        private Guild guild;
        private Market market;
        private Canteen canteen;
        private GeneralBank generalBank;
        private Logger logger;

        public SimulationEngine()
        {
            _currentSimulationState = new SimulationState();
            hospital = new Hospital();
            mineSupervisor = new MineSupervisor();
            guild = new Guild();
            market = new Market();
            canteen = new Canteen();
            generalBank = new GeneralBank();
            logger = Logger.Instance;
        }

        public void Start()
        {
            canteen.FoodRations = 200;
            _currentSimulationState.Dwarves = hospital.BuildInitialSocietyMembers();
            for (int i = 0; i < 30; i++)
            {

                logger.AddLog($"\n\nDay {i+1}\n\n");
                //Hospital.TryToBorn(currentSimulationState) -> Dwarf or Null;
                BirthDwarf(hospital);

                //Mine.Work(List<Backpack>,List<dwarfType>) -> aktualizacja Backpack;
                var dwarfBackpacks = _currentSimulationState.Dwarves.Select(p => p.Backpack).ToList();
                var dwarfTypes = _currentSimulationState.Dwarves.Select(p => p.DwarfType).ToList();
                var dwarfLifeStatus = _currentSimulationState.Dwarves.Select(p => p.IsAlive).ToList();

                mineSupervisor.Work(ref dwarfBackpacks, dwarfTypes, ref dwarfLifeStatus);

                UpdateDwarfLifeStatus(dwarfLifeStatus);
                UpdateDwarfBackpacks(dwarfBackpacks);

                //Guild.PayWorkers(List<BankAccount> bankAccounts, backpacks);
                guild.DwarvesVisitGuild(_currentSimulationState.Dwarves);

                market.PerformShopping(_currentSimulationState.Dwarves, generalBank);

                _currentSimulationState.NumberOfDeadDwarves = _currentSimulationState.Dwarves.Where(p => p.IsAlive == false).Count();

                //Canteen(numberOfWorkersToday)
                var aliveDwarves = _currentSimulationState.Dwarves.Where(p => p.IsAlive == true).Count();
                canteen.GiveFoodRations(aliveDwarves);
                canteen.OrderFoodRations();

                UpdateAccount.MoveDailyPaymentToAccount(_currentSimulationState.Dwarves);
                

                if (ShouldSimulationBeContinued(canteen) > 0)
                {
                    break;
                }
            }
            PrepareFinalState();
            logger.GenerateReport(_currentSimulationState);
        }

        private int ShouldSimulationBeContinued(Canteen canteen)
        {
            if (_currentSimulationState.NumberOfDeadDwarves == _currentSimulationState.Dwarves.Count ||
                _currentSimulationState.Dwarves.Where(p => p.IsAlive).Count() > canteen.FoodRations)
            {
                return 1;
            }
            return 0;
        }

        private void PrepareFinalState()
        {
            _currentSimulationState.NumberOfBirths = hospital.totalNumberOfBirth;
            _currentSimulationState.guildBankAccount = guild.Account.OverallAccount;
            _currentSimulationState.taxBankAccount = generalBank.BankTresure();
            _currentSimulationState.marketState = market._marketState;
            _currentSimulationState.extractedOre = mineSupervisor.GetMineSupervisorStats;
        }

        private void BirthDwarf(Hospital hospital)
        {
            var dwarf = hospital.TryToCreateDwarf();
            if (dwarf != null)
            {
                _currentSimulationState.Dwarves.Add(dwarf);
            }
        }

        private void UpdateDwarfBackpacks(System.Collections.Generic.List<PersonalItems.Backpack> dwarfBackpacks)
        {
            for (int k = 0; k < _currentSimulationState.Dwarves.Count; k++)
            {
                _currentSimulationState.Dwarves[k].Backpack = dwarfBackpacks[k];
            }
        }

        private void UpdateDwarfLifeStatus(System.Collections.Generic.List<bool> dwarfLifeStatus)
        {
            for (int j = 0; j < _currentSimulationState.Dwarves.Count; j++)
            {
                _currentSimulationState.Dwarves[j].IsAlive = dwarfLifeStatus[j];
            }
        }
    }
}