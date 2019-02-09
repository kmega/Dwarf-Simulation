using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;

namespace DwarfLife.LifeCycles
{
    public class LifeCycle
    {
        int _maxDays;
        public LifeCycleState LifeCycleState { get; private set; }

        public LifeCycle(int maxDays = 30)
        {
            _maxDays = maxDays;
            LifeCycleState = new LifeCycleState();
        }

        public LifeCycle(List<IDwarf> dwarfs, int maxDays = 30)
        {
            LifeCycleState = new LifeCycleState(dwarfs);
            _maxDays = maxDays;
        }

        public void Begin()
        {
            while(IsEndOfLifeCycle())
                DayPasses();
        }

        private void DayPasses()
        {
            LifeCycleState.DaysPassed++;
        }

        private bool IsEndOfLifeCycle()
        {
            if (LifeCycleState.DaysPassed == _maxDays)
                return false;
            if (LifeCycleState.Dwarfs.Count == 0)
                return false;
            if (LifeCycleState.Rations < 1)
                return false;

            return true;
        }

        public int MaxDays()
        {
            return _maxDays;
        }
    }
}
