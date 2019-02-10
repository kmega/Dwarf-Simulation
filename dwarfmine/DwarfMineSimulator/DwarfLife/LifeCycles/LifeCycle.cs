using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;
using DwarfLife.Diaries;

namespace DwarfLife.LifeCycles
{
    public class LifeCycle
    {
        readonly int _maxDays;
        public LifeCycleState LifeCycleState { get; private set; }

        public LifeCycle(int maxDays = 30)
        {
            _maxDays = maxDays;
            LifeCycleState = new LifeCycleState();

            DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("New LifeCycle has been created with max days {0}.",
                        _maxDays));
        }

        public LifeCycle(List<IDwarf> dwarfs, int maxDays = 30)
        {
            _maxDays = maxDays;
            LifeCycleState = new LifeCycleState(dwarfs);
        }

        public void Begin()
        {
            while(IsEndOfLifeCycle())
                DayPasses();
        }

        public int MaxDays()
        {
            return _maxDays;
        }

        private void DayPasses()
        {
            LifeCycleState.DaysPassed++;

            DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("In LifeCycle another day passed. There is {0} days passed.",
                        LifeCycleState.DaysPassed));
        }

        private bool IsEndOfLifeCycle()
        {
            if (LifeCycleState.DaysPassed == _maxDays)
            {
                DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("LifeCycle has been ended because reach {0} of {1} max days of lifecycle.",
                        LifeCycleState.DaysPassed, _maxDays));
                return false;
            }
            if (LifeCycleState.Dwarfs.Count == 0)
            {
                DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("LifeCycle has been ended because there is no dwarfs anymore."));
                return false;
            }

            if (LifeCycleState.Rations < 1)
            {
                DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("LifeCycle has been ended because there is no food rations anymore."));
                return false;
            }

            return true;
        }
    }
}
