using System;
using System.Collections.Generic;
using System.Linq;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Mine.ActionsForWorkersInSchaft;
using MiningSimulatorByKPMM.Locations.Mine.Enums;
using MiningSimulatorByKPMM.Locations.Mine.Factories;
using MiningSimulatorByKPMM.Locations.Mine.Interfaces;
using MiningSimulatorByKPMM.Locations.Mine.SubMineLocations;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public class MineSupervisor
    {
        private readonly IOreRandomizer oreRandomizer = new OreRandomizer();
        private readonly IOreUnitAmountRandomizer oreUnitAmountRandomizer = new OreUnitAmountRandomizer();
        private List<MiningSchaft> Schafts { get; set; }
        private TeamSplitter TeamSplitter = new TeamSplitter();
        private List<Backpack> workingBackpackList = new List<Backpack>();
        private List<E_DwarfType> workingTypeList = new List<E_DwarfType>();
        private List<bool> workingBools = new List<bool>();
        private List<TemporaryWorker> AllWorkers = new List<TemporaryWorker>();

        public Dictionary<E_Minerals, int> GetMineSupervisorStats { get; } = new Dictionary<E_Minerals, int>()
        {
            {E_Minerals.DirtGold, 0},
            {E_Minerals.Gold, 0},
            {E_Minerals.Mithril, 0},
            {E_Minerals.Silver, 0},
        };

        public List<TemporaryWorker> GetAllWorkers() => AllWorkers;

        public E_MiningSchaftStatus[] GetTwoSchaftsStatus()
        {
            return new E_MiningSchaftStatus[] { Schafts[0].GetSchaftStatus(), Schafts[1].GetSchaftStatus() };
        }

        public MineSupervisor()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public class TemporaryWorker
        {
            public Backpack backpack;
            public E_DwarfType type;
            public bool isAlive;

            public TemporaryWorker(Backpack backpack, E_DwarfType type, bool isalive)
            {
                this.backpack = backpack;
                this.type = type;
                this.isAlive = isalive;
            }

            public override string ToString()
            {
                return type.ToString();
            }
        }

        public void Work(ref List<Backpack> backpackList, List<E_DwarfType> typeList, ref List<bool> isAliveList)
        {
            FixAllSchafts();
            CreateTemporaryObjectsFromParameters(backpackList, typeList, isAliveList);
            WorkProcessing();
            UpdateDailyMineStats();

            isAliveList = UnwrapAllWorkersAndChangeStatesOfParameters(backpackList, typeList, isAliveList);
        }

        private void UpdateDailyMineStats()
        {
            foreach (var mineral in Enum.GetValues(typeof(E_Minerals)))
            {
                foreach (var worker in AllWorkers)
                {
                    int sum = 0;
                    var AmountOfMineralsOfNotDeadWorkers = worker.backpack.ShowBackpackContent().Count(x => x.OutputType == (E_Minerals)mineral);
                    if(AmountOfMineralsOfNotDeadWorkers != 0)
                    {
                        sum += AmountOfMineralsOfNotDeadWorkers;
                        GetMineSupervisorStats[(E_Minerals)mineral] += sum;
                    }
                }
            }
        }

        private List<bool> UnwrapAllWorkersAndChangeStatesOfParameters(List<Backpack> backpackList, List<E_DwarfType> typeList, List<bool> isAliveList)
        {
            List<Backpack> unwrappedBackpacks = new List<Backpack>();
            List<E_DwarfType> unwrappedTypeLists = new List<E_DwarfType>();
            List<bool> unwrappedIsAliveList = new List<bool>();

            AllWorkers.ForEach(x => unwrappedBackpacks.Add(x.backpack));
            AllWorkers.ForEach(x => unwrappedTypeLists.Add(x.type));
            AllWorkers.ForEach(x => unwrappedIsAliveList.Add(x.isAlive));

            backpackList = unwrappedBackpacks;
            typeList = unwrappedTypeLists;
            //isAliveList = unwrappedIsAliveList;

            return unwrappedIsAliveList;
        }

        private void FixAllSchafts()
        {
            Schafts.ForEach(x => x.FixSchaft());
        }

        private void CreateTemporaryObjectsFromParameters(List<Backpack> backpackList, List<E_DwarfType> typeList, List<bool> isAliveList)
        {
            if (backpackList.Count != typeList.Count)
                throw new Exception("Ops... lists are not equal");

            workingBackpackList = backpackList;
            workingTypeList = typeList;
            workingBools = isAliveList;

            for (int i = 0; i < backpackList.Count; i++)
            {
                Backpack temporaryBackpack = workingBackpackList[i];
                E_DwarfType temporaryType = workingTypeList[i];
                bool temporaryIsAlive = workingBools[i];

                AllWorkers.Add(new TemporaryWorker(temporaryBackpack, temporaryType, temporaryIsAlive));
            }
        }

        private void WorkProcessing()
        {
            do
            {
                SendWorokersToCertainSchafts();

                foreach (var schaft in Schafts)
                {
                    if (schaft.GetSchaftStatus() != E_MiningSchaftStatus.Broken)
                    {
                        schaft.ExecuteWorkStrategy(oreRandomizer, oreUnitAmountRandomizer);
                        AllWorkers.AddRange(schaft.RemoveWorkersFromSchaft());
                    }
                }
            } while (IfCanStillWork());
        }

        private bool IfCanStillWork()
        {
            bool condition = false;

            foreach (var worker in AllWorkers)
            {
                if (worker.backpack.ShowBackpackContent().Count == 0 && worker.isAlive == true)
                    condition = true;
                //else condition = false;
            }

            //if (Schafts[0].GetSchaftStatus() == E_MiningSchaftStatus.Broken &&
            //Schafts[1].GetSchaftStatus() == E_MiningSchaftStatus.Broken) ;
            if (Schafts.All(x => x.GetSchaftStatus() == E_MiningSchaftStatus.Broken))
                condition = false;

            return condition;
        }

        private void SendWorokersToCertainSchafts()
        {
            foreach (MiningSchaft schaft in Schafts)
            {
                if (schaft.GetSchaftStatus() != E_MiningSchaftStatus.Broken)
                {
                    var CurrentlyWorkingTeam = TeamSplitter.SplitWorkersIntoTeam(AllWorkers.Where(x => x.backpack.ShowBackpackContent().Count == 0 && x.isAlive == true).ToList());
                    RemoveWorkingMinersFromAllworkers(CurrentlyWorkingTeam);
                    schaft.SetSchaftWorkers(CurrentlyWorkingTeam);
                }
            }
        }

        private void RemoveWorkingMinersFromAllworkers(List<TemporaryWorker> temp)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                AllWorkers.Remove(temp[i]);
            }
        }
    }
}