using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Hospital.RandomGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Hospital
{
    public class Hospital
    {
        IBirthChanceRandomizer birthChanceRandomizer;
        IDwarfTypeRandomizer dwarfTypeRandomizer;

        #region Constructors
        public Hospital(IBirthChanceRandomizer birthChanceRandomizer,
            IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            this.birthChanceRandomizer = birthChanceRandomizer;
            this.dwarfTypeRandomizer = dwarfTypeRandomizer;
        }
        public Hospital()
        {
            birthChanceRandomizer = new IsDwarfBorn1PercentStrategy();
            dwarfTypeRandomizer = new DwarfTypeGenerator();
        }
        #endregion

        public Dwarf TryToCreateDwarf()
        {
            if(birthChanceRandomizer.IsDwarfBorn())
            {
                E_DwarfType type = dwarfTypeRandomizer.GenerateType();
                Console.WriteLine($"{type} is born!");
                return new Dwarf(type);
            }
            return null;
        }
        public List<Dwarf> BuildInitialSocietyMembers()
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            for(int i = 0; i < 10; i++)
            {
                dwarves.Add(new Dwarf(dwarfTypeRandomizer.GenerateType()));
            }
            Console.WriteLine($"Initial Society Size: {dwarves.Count}");
            return dwarves;
        }
    }
}
