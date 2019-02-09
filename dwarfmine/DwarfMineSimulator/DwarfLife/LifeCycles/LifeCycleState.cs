using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;

namespace DwarfLife.LifeCycles
{
    public class LifeCycleState
    {
        public int DaysPassed { get; private set; }
        public int Rations { get; private set; }
        public List<IDwarf> Dwarfs { get; private set; }

        public LifeCycleState()
        {
            DaysPassed = 0;
            Rations = 200;
            Dwarfs = new List<IDwarf>();
        }

        public LifeCycleState(List<IDwarf> dwarfs)
        {
            DaysPassed = 0;
            Rations = 200;
            Dwarfs = dwarfs;
        }
    }
}
