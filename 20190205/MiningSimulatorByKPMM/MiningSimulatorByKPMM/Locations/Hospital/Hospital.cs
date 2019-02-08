using MiningSimulatorByKPMM.ApplicationLogic;
using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Enums;
using MiningSimulatorByKPMM.Locations.Hospital.RandomGenerators;
using MiningSimulatorByKPMM.Reports;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiningSimulatorByKPMM.Locations.Hospital
{
    public class Hospital
    {
        public int totalNumberOfBirth;
        private ILogger logger;
        private IBirthChanceRandomizer birthChanceRandomizer;
        private IDwarfTypeRandomizer dwarfTypeRandomizer;

        #region Constructors

        public Hospital(IBirthChanceRandomizer birthChanceRandomizer,
            IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            SetInitialState(birthChanceRandomizer, dwarfTypeRandomizer);
        }

        public Hospital()
        {
            SetInitialState(new IsDwarfBorn1PercentStrategy(), 
                new DwarfTypeGenerator());
        }

        #endregion Constructors

        private void SetInitialState(IBirthChanceRandomizer birthChanceRandomizer, 
            IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            this.birthChanceRandomizer = birthChanceRandomizer;
            this.dwarfTypeRandomizer = dwarfTypeRandomizer;
            logger = Logger.Instance;
            totalNumberOfBirth = 0;
        }

        public List<Dwarf> CreateDwarf()
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            if (birthChanceRandomizer.IsDwarfBorn())
            {
                E_DwarfType type = dwarfTypeRandomizer.GenerateType();                
                logger.AddLog($"A {type} is born.");
                totalNumberOfBirth++;
                dwarves.Add(new Dwarf(type));
            }
            return dwarves;
        }

        public List<Dwarf> BuildInitialDwarves()
        {
            List<Dwarf> dwarves = new List<Dwarf>();
            for (int i = 0; i < 10; i++)
            {
                dwarves.Add(new Dwarf(dwarfTypeRandomizer.GenerateType()));
            }
            logger.AddLog($"Initial Society Size: {dwarves.Count}");
            return dwarves;
        }
    }
}