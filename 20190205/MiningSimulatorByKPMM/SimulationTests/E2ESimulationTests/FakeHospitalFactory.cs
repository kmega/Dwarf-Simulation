using MiningSimulatorByKPMM.DwarfsTypes;
using MiningSimulatorByKPMM.Locations.Hospital;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimulationTests.E2ESimulationTests
{
    internal static class FakeHospitalFactory
    {
        internal static Hospital Create(IBirthChanceRandomizer birthChanceRandomizer, IDwarfTypeRandomizer dwarfTypeRandomizer)
        {
            return new Hospital(birthChanceRandomizer, dwarfTypeRandomizer);
        }
    }
}
