using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf
    {
        public E_DwarfType DwarfType { get; set; }
        public decimal BankAccount { get; set; }
        public decimal DailySalary { get; set; }
        public List<E_MineralsType> PersonalEquipment { get; set; }
    }
}