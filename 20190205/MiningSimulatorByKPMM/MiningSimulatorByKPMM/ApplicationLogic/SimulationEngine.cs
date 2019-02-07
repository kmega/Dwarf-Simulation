using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.Reports;
using System;
using System.Linq;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationEngine
    {
        private SimulationState _currentSimulationState;
        Hospital hospital;
        MineSupervisor mineSupervisor;
        Guild guild;
        Market market;
        Canteen canteen;
        GeneralBank generalBank;
        Logger logger;

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

                //Canteen(numberOfWorkersToday);
                canteen.GiveFoodRations(_currentSimulationState.Dwarves.Count);
                canteen.OrderFoodRations();

                UpdateAccount.MoveDailyPaymentToAccount(_currentSimulationState.Dwarves);
                //
            }

            PrepareFinalState();
            logger.GenerateReport(_currentSimulationState);



        }

        private void PrepareFinalState()
        {
            _currentSimulationState.NumberOfBirths = hospital.totalNumberOfBirth;
            _currentSimulationState.guildBankAccount = guild.Account.OverallAccount;
            _currentSimulationState.taxBankAccount = generalBank.BankTresure();
            _currentSimulationState.marketState = market.marketState;
            
            
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