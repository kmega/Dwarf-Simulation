using System;
using System.Collections.Generic;
using DwarfLife.Dwarfs;
using DwarfLife.Diaries;

namespace DwarfLife.LifeCycles
{
    public class LifeCycle
    {

        public LifeCycleState LifeCycleState { get; private set; }

        public LifeCycle(int maxDays = 30)
        {
            LifeCycleState = new LifeCycleState(maxDays);

            DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("New LifeCycle has been created with max days {0}.",
                        LifeCycleState.MaxDays));
        }

        public LifeCycle(List<IDwarf> dwarfs, int maxDays = 30)
        {
            LifeCycleState = new LifeCycleState(dwarfs, maxDays);
        }

        public void Begin()
        {
            while(IsEndOfLifeCycle())
                DayPasses();
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
            if (LifeCycleState.DaysPassed == LifeCycleState.MaxDays)
            {
                DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("LifeCycle has been ended because reach {0} of {1} max days of lifecycle.",
                        LifeCycleState.DaysPassed, LifeCycleState.MaxDays));
                return false;
            }
            if (LifeCycleState.Dwarfs.Count == 0)
            {
                DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("LifeCycle has been ended because there is no dwarfs anymore."));
                return false;
            }

            if (LifeCycleState.Canteen.Rations < 1)
            {
                DiaryHelper.Log(Constans.diaryTarget,
                        string.Format("LifeCycle has been ended because there is no food rations anymore."));
                return false;
            }

            return true;
        }
    }
}
