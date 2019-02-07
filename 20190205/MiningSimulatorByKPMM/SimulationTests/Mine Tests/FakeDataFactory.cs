using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;
using static MiningSimulatorByKPMM.Locations.Mine.MineSupervisor;

namespace SimulationTests.MineTests
{
    public static class FakeDataFactory
    {
        public static List<TemporaryWorker> CreateXNonSluggardWorkers(int amount)
        {
            List<TemporaryWorker> tempObjs = new List<TemporaryWorker>();
            for (int i = 0; i < amount; i++)
            {
                tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true));
            }

            return tempObjs;
        }

        public static List<TemporaryWorker> CreateTwoSluggardWorkersInBothTeams(int amount)
        {
            List<TemporaryWorker> tempObjs = new List<TemporaryWorker>();
            for (int i = 0; i < amount; i++)
            {
                if(i==0)
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Sluggard, true));
                else if(i==5)
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Sluggard, true));
                else
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true));
            }

            return tempObjs;
        }

        public static List<TemporaryWorker> CreateSluggardWorkers(int amount)
        {
            List<TemporaryWorker> tempObjs = new List<TemporaryWorker>();
            for (int i = 0; i < amount; i++)
            {
                if(i==0)
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Sluggard, true));
                else
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true));
            }

            return tempObjs;
        }

        internal static List<TemporaryWorker> CreateSluggardWorkerOnlyInSecondSchaft(int amount)
        {
            List<TemporaryWorker> tempObjs = new List<TemporaryWorker>();
            for (int i = 0; i < amount; i++)
            {
                if (i == 5)
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Sluggard, true));
                else
                    tempObjs.Add(new TemporaryWorker(new Backpack(), E_DwarfType.Dwarf_Father, true));
            }

            return tempObjs;
        }

        public static (List<Backpack>, List<E_DwarfType>, List<bool>) ExtractListsFromWorkers(List<TemporaryWorker> workers)
        {
            List<Backpack> backpacks = new List<Backpack>();
            List<E_DwarfType> dwarfTypes = new List<E_DwarfType>();
            List<bool> bools = new List<bool>();

            foreach (var worker in workers)
            {
                backpacks.Add(worker.backpack);
                dwarfTypes.Add(worker.type);
                bools.Add(worker.isAlive);
            }

            return (backpacks, dwarfTypes, bools);
        }
    }
}
