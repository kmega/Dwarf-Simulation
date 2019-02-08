using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Bank;
using MiningSimulatorByKPMM.Locations.Canteen;
using MiningSimulatorByKPMM.Locations.Guild;
using MiningSimulatorByKPMM.Locations.Hospital;
using MiningSimulatorByKPMM.Locations.Market;
using MiningSimulatorByKPMM.Locations.Mine;
using MiningSimulatorByKPMM.Reports;
using System.Collections.Generic;
using System.Linq;

namespace MiningSimulatorByKPMM.ApplicationLogic
{
    public class SimulationEngine
    {
        public void Start()
        {
            var simulationState = new SimulationState();
            var hospital = new Hospital();
            var mineSupervisor = new MineSupervisor();
            var guild = new Guild(new Dictionary<E_Minerals, ICreateOreValue>()
            { { E_Minerals.Gold, new ValueOfGold() },
                {E_Minerals.DirtGold, new ValueOfDirtGold() },
                {E_Minerals.Mithril, new ValueOfMithril() },
                {E_Minerals.Silver, new ValueOfSilver()}
            });
            var market = new Market();
            var canteen = new Canteen();
            var generalBank = new GeneralBank();
            var logger = Logger.Instance;

            canteen.FoodRations = 200;
            simulationState.Dwarves = hospital.BuildInitialDwarves();
            for (int i = 0; i < 30; i++)
            {
                logger.AddLog($"\n\nDay {i + 1}\n\n");

                BirthDwarf(hospital, simulationState);
                MiningTreasures(simulationState, mineSupervisor);
                guild.DwarvesVisitGuild(simulationState.Dwarves);
                market.PerformShopping(simulationState.Dwarves, generalBank);
                canteen.GiveFoodRations(GetAliveDwarves(simulationState));
                canteen.OrderFoodRations();
                UpdateAccount.MoveDailyPaymentToAccount(simulationState.Dwarves);

                if (ShouldSimulationBeContinued(canteen, simulationState))
                {
                    break;
                }
            }
            logger.DisplayReport(EndState(simulationState, hospital, guild, generalBank, market, mineSupervisor));
        }

        private int GetAliveDwarves(SimulationState simulationState)
        {
            return simulationState.Dwarves.Where(p => p.IsAlive == true).Count();
        }

        private void MiningTreasures(SimulationState simulationState, MineSupervisor mineSupervisor)
        {
            var dwarfBackpacks = simulationState.Dwarves.Select(p => p.Backpack).ToList();
            var dwarfTypes = simulationState.Dwarves.Select(p => p.DwarfType).ToList();
            var dwarfLifeStatus = simulationState.Dwarves.Select(p => p.IsAlive).ToList();

            mineSupervisor.Work(ref dwarfBackpacks, dwarfTypes, ref dwarfLifeStatus);

            UpdateDwarfLifeStatus(dwarfLifeStatus, simulationState);
            UpdateDwarfBackpacks(dwarfBackpacks, simulationState);
        }

        private bool ShouldSimulationBeContinued(Canteen canteen, SimulationState simulationState)
        {
            if (simulationState.NumberOfDeadDwarves == simulationState.Dwarves.Count ||
                simulationState.Dwarves.Where(p => p.IsAlive).Count() > canteen.FoodRations)
            {
                return true;
            }
            return false;
        }

        private SimulationState EndState(SimulationState simulationState, Hospital hospital, Guild guild, GeneralBank generalBank, Market market, MineSupervisor mineSupervisor)
        {
            simulationState.NumberOfBirths = hospital.totalNumberOfBirth;
            simulationState.GuildBankAccount = guild.Account.OverallAccount;
            simulationState.TaxBankAccount = generalBank.BankTresure();
            simulationState.MarketState = market.marketState;
            simulationState.ExtractedOre = mineSupervisor.MineSupervisorStats;
            return simulationState;
        }

        private void BirthDwarf(Hospital hospital, SimulationState simulationState)
        {
            var dwarves = hospital.CreateDwarf();
            simulationState.Dwarves.AddRange(dwarves);
        }

        private void UpdateDwarfBackpacks(List<PersonalItems.Backpack> dwarfBackpacks, SimulationState simulationState)
        {
            for (int k = 0; k < simulationState.Dwarves.Count; k++)
            {
                simulationState.Dwarves[k].Backpack = dwarfBackpacks[k];
            }
        }

        private void UpdateDwarfLifeStatus(List<bool> dwarfLifeStatus, SimulationState simulationState)
        {
            for (int j = 0; j < simulationState.Dwarves.Count; j++)
            {
                simulationState.Dwarves[j].IsAlive = dwarfLifeStatus[j];
            }
        }
    }
}
