using System;
using DwarfLife.Diaries;

namespace DwarfLife.Buildings.Canteen
{
    public class Canteen
    {
        public int Rations { get; set; }

        public Canteen(int rations = 200)
        {
            Rations = rations;

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("New Canteen created with rations amound of {0}.",
                Rations));
        }

        private bool IsRationsBelow10()
        {
            return Rations < 10;
        }

        private void OrderRations()
        {
            Rations += 30;

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Canteen ordered rations amound of {0}.",
                30));

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Canteen has now {0} rations.",
                Rations));
        }
    }
}
