using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Factories;
using MiningSimulatorByKPMM.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Hospital
{
    public class Hospital
    {
        Dictionary<string, IRandomGenerator> randomGenerators;
        public Hospital()
        {
            randomGenerators = new Dictionary<string, IRandomGenerator>();
            randomGenerators.Add("Birth", new DwarfBirthChanceGenerator());
            randomGenerators.Add("DwarfType", new DwarfTypeGenerator());
        }
        public Dwarf TryToCreateDwarf()
        {
            if(!Convert.ToBoolean(randomGenerators["Birth"].GenerateSignleRandomNumber()))
            {
                int dwarfType = randomGenerators["DwarfType"].GenerateSignleRandomNumber();
                E_DwarfType type = GetDwarfType(dwarfType);
                return DwarfFactory.Create(type);
            }
            return null;
        }
        private E_DwarfType GetDwarfType(int dwarfType)
        {
            if(dwarfType == 0)
            {
                return E_DwarfType.Dwarf_Suicide;
            }
            else if(dwarfType > 0 && dwarfType <=33)
            {
                return E_DwarfType.Dwarf_Father;
            }
            else if(dwarfType > 33 && dwarfType <= 66)
            {
                return E_DwarfType.Dwarf_Single;
            }
            else
            {
                return E_DwarfType.Dwarf_Sluggard;
            }
        }
    }
}
