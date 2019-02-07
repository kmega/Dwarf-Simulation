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
        //private List<List<TemporaryWorker>> SchaftOpeartingTeams = new List<List<TemporaryWorker>>();

        //Mine.Work(List<Backpack>,List<dwarfType>) -> aktualizacja Backpack;
        public List<TemporaryWorker> GetTemporaryWorkers() => AllWorkers;

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

        public MineSupervisor()
        {
            Schafts = SchaftFactory.CreateTwoSchafts();
        }

        public void Work(List<Backpack> backpackList, List<E_DwarfType> typeList, List<bool> isAliveList )
        {
            FixAllSchafts();
            CreateTemporaryObjectsFromParameters(backpackList, typeList, isAliveList);
            WorkProcessing();

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
                    schaft.ExecuteWork(oreRandomizer, oreUnitAmountRandomizer);
                    AllWorkers.AddRange(schaft.RemoveWorkersFromSchaft());
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
            }

            if (Schafts[0].GetSchaftStatus() == E_MiningSchaftStatus.Broken &&
                        Schafts[1].GetSchaftStatus() == E_MiningSchaftStatus.Broken)
                condition = false;

            return condition;
        }

        private void SendWorokersToCertainSchafts()
        {
            foreach (MiningSchaft schaft in Schafts)
            {
                if(schaft.GetSchaftStatus() != E_MiningSchaftStatus.Broken)
                {
                    var team = TeamSplitter.SplitWorkersIntoTeam(AllWorkers.Where(x => x.backpack.ShowBackpackContent().Count == 0).ToList());
                    NewMethod(team);
                    schaft.SetSchaftWorkers(team);
                }
            }
        }

        private void NewMethod(List<TemporaryWorker> temp)
        {
            for (int i = 0; i < temp.Count; i++)
            {
                AllWorkers.Remove(temp[i]);
            }
        }
    }
}
