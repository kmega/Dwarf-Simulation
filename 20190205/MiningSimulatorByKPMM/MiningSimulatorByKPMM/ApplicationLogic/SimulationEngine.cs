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
        private SimulationState _simulationState;
        private Hospital _hospital;
        private MineSupervisor _mineSupervisor;
        private Guild _guild;
        private Market _market;
        private Canteen _canteen;
        private GeneralBank _generalBank;
        private Logger _logger;

        public SimulationEngine()
        {
            _simulationState = new SimulationState();
            _hospital = new Hospital();
            _mineSupervisor = new MineSupervisor();
            _guild = new Guild();
            _market = new Market();
            _canteen = new Canteen();
            _generalBank = new GeneralBank();
            _logger = Logger.Instance;
        }

        public void Start()
        {
            _canteen.FoodRations = 200;
            _simulationState.Dwarves = _hospital.BuildInitialDwarves();
            for (int i = 0; i < 30; i++)
            {
                _logger.AddLog($"\n\nDay {i + 1}\n\n");

                BirthDwarf(_hospital);
                MiningTreasures();
                _guild.DwarvesVisitGuild(_simulationState.Dwarves);
                _market.PerformShopping(_simulationState.Dwarves, _generalBank);
                _canteen.GiveFoodRations(GetAliveDwarves());
                _canteen.OrderFoodRations();
                UpdateAccount.MoveDailyPaymentToAccount(_simulationState.Dwarves);

                if (ShouldSimulationBeContinued(_canteen))
                {
                    break;
                }
            }
            _logger.GenerateReport(EndState());
        }

        private int GetAliveDwarves()
        {
            return _simulationState.Dwarves.Where(p => p.IsAlive == true).Count();
        }

        private void MiningTreasures()
        {
            var dwarfBackpacks = _simulationState.Dwarves.Select(p => p.Backpack).ToList();
            var dwarfTypes = _simulationState.Dwarves.Select(p => p.DwarfType).ToList();
            var dwarfLifeStatus = _simulationState.Dwarves.Select(p => p.IsAlive).ToList();

            _mineSupervisor.Work(ref dwarfBackpacks, dwarfTypes, ref dwarfLifeStatus);

            UpdateDwarfLifeStatus(dwarfLifeStatus);
            UpdateDwarfBackpacks(dwarfBackpacks);
        }

        private bool ShouldSimulationBeContinued(Canteen canteen)
        {
            if (_simulationState.NumberOfDeadDwarves == _simulationState.Dwarves.Count ||
                _simulationState.Dwarves.Where(p => p.IsAlive).Count() > canteen.FoodRations)
            {
                return true;
            }
            return false;
        }

        private SimulationState EndState()
        {
            _simulationState.NumberOfBirths = _hospital.totalNumberOfBirth;
            _simulationState.GuildBankAccount = _guild.Account.OverallAccount;
            _simulationState.TaxBankAccount = _generalBank.BankTresure();
            _simulationState.MarketState = _market.marketState;
            _simulationState.ExtractedOre = _mineSupervisor.MineSupervisorStats;
            return _simulationState;
        }

        private void BirthDwarf(Hospital hospital)
        {
            var dwarves = hospital.CreateDwarf();
            _simulationState.Dwarves.AddRange(dwarves);
        }

        private void UpdateDwarfBackpacks(System.Collections.Generic.List<PersonalItems.Backpack> dwarfBackpacks)
        {
            for (int k = 0; k < _simulationState.Dwarves.Count; k++)
            {
                _simulationState.Dwarves[k].Backpack = dwarfBackpacks[k];
            }
        }

        private void UpdateDwarfLifeStatus(System.Collections.Generic.List<bool> dwarfLifeStatus)
        {
            for (int j = 0; j < _simulationState.Dwarves.Count; j++)
            {
                _simulationState.Dwarves[j].IsAlive = dwarfLifeStatus[j];
            }
        }
    }
}