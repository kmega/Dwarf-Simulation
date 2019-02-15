using DwarfLifeSimulation.Dwarves.Interfaces;
using DwarfLifeSimulation.Enums;
using DwarfLifeSimulation.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DwarfLifeSimulation.Locations.Mines.ShiftGroups
{
    public class ShiftGroup
    {
        public List<IWork> Members { get; set; }
        private ILog _logger;
        public ShiftGroup(ILog logger)
        {
            Members = new List<IWork>();
            _logger = logger;
        }

        public void EnterShaft(Shaft shaft)
        {
            foreach (var member in Members)
            {
                member.Work(shaft, _logger);
                member._hasWorked = true;
            }
            if(shaft.ShaftStatus == ShaftStatus.Destroyed)
            {
                KillWorkers(shaft);
            }
        }
        private void KillWorkers(Shaft shaft)
        {
            foreach (var member in Members)
            {
                member._isAlive = false;
            }
        }
    }
}
