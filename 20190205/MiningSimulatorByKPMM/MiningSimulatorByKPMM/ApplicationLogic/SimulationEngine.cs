using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Mine;
using System;
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

                //Canteen(numberOfWorkersToday); nie karm martwych!!
                canteen.GiveFoodRations(_currentSimulationState.Dwarves.Count);
                canteen.OrderFoodRations();

                

                UpdateAccount.MoveDailyPaymentToAccount(_currentSimulationState.Dwarves);

                var a = ShouldSimulationBeContinued(canteen);
                if (a == 1)
                {
                    break;
                }
            }
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