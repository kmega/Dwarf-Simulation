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
        private int totalNumberOfBirth;
        private ILogger logger;
        IBirthChanceRandomizer birthChanceRandomizer;
        IDwarfTypeRandomizer dwarfTypeRandomizer;

        #region Constructors
        public Hospital(IBirthChanceRandomizer birthChanceRandomizer,
            IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            SetInitialState();
            this.birthChanceRandomizer = birthChanceRandomizer;
            this.dwarfTypeRandomizer = dwarfTypeRandomizer;
        }
        public Hospital()
        {
            SetInitialState();
            birthChanceRandomizer = new IsDwarfBorn1PercentStrategy();
            dwarfTypeRandomizer = new DwarfTypeGenerator();
        }
        #endregion

        private void SetInitialState()
        {
            logger = Logger.Instance;
            totalNumberOfBirth = 0;
        }

        public Dwarf TryToCreateDwarf()
        {
            if(birthChanceRandomizer.IsDwarfBorn())
            {
                E_DwarfType type = dwarfTypeRandomizer.GenerateType();
                logger.AddLog($"A {type} is born.");
                totalNumberOfBirth++;
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
            logger.AddLog($"Initial Society Size: {dwarves.Count}");
            return dwarves;
        }
    }
}
