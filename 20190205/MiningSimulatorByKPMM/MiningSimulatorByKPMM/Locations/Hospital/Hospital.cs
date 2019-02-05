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
        List<IRandomGenerator> randomGenerator;
        public Hospital(List<IRandomGenerator> generator)
        {
            if(generator == null)
            {
                randomGenerator = new List<IRandomGenerator>()
                {
                    new DwarfBirthChanceGenerator(),
                    new DwarfBirthChanceGenerator()
                };
            }
            else
            {
                randomGenerator = generator;
            }
        }
        public Dwarf TryToCreateDwarf()
        {
            if(!Convert.ToBoolean(randomGenerator[0].GenerateSignleRandomNumber()))
            {
                int dwarfType = randomGenerator[1].GenerateSignleRandomNumber();
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
