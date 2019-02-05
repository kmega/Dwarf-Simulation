using System.Collections.Generic;
using MiningSimulatorByKPMM.Enums;

namespace MiningSimulatorByKPMM.DwarfsTypes
{
    public class Dwarf
    {
        E_DwarfType DwarfType { get; set; }
        decimal BankAccount { get; set; }
        decimal DailySalary { get; set; }
        List<E_Minerals> PersonalEquipment { get; set; }
    }
}