using System;
using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.PersonalItems;

namespace MiningSimulatorByKPMM.Locations.Mine
{
    public partial class MineSupervisor
    {
        public class TemporaryWorkerFactory
        {
            public List<TemporaryWorker> CreateListTemporaryWorkersFromParameters(List<Backpack> backpackList, List<E_DwarfType> typeList, List<bool> isAliveList)
            {
                if (backpackList.Count != typeList.Count)
                    throw new Exception("Ops... lists are not equal");

                List<TemporaryWorker> _allWorkers = new List<TemporaryWorker>();

                for (int i = 0; i < backpackList.Count; i++)
                {
                    Backpack temporaryBackpack = backpackList[i];
                    E_DwarfType temporaryType = typeList[i];
                    bool temporaryIsAlive = isAliveList[i];

                    _allWorkers.Add(new TemporaryWorker(temporaryBackpack, temporaryType, temporaryIsAlive));
                }

                return _allWorkers;
            }
        }
    }
}