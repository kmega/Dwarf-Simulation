using System;
using DwarfLife.Diaries;

namespace DwarfLife.Buildings.Canteen
{
    public class Canteen
    {
        public int RationsEaten { get; private set; }
        public int RationsOrdered { get; private set; }
        public int Rations { get; private set; }

        public Canteen(int rations = 200)
        {
            Rations = rations;
            RationsEaten = 0;
            RationsOrdered = 0;

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("New Canteen created with rations amound of {0}.",
                Rations));
        }

        public void GiveFood()
        {
            Rations--;
            RationsEaten++;
        }

        public void CheckSupplies()
        {
            if (IsRationsBelow10())
                OrderRations();
        }

        private bool IsRationsBelow10()
        {
            return Rations < 10;
        }

        private void OrderRations()
        {
            Rations += 30;
            RationsOrdered += 30;

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Canteen ordered rations amound of {0}.",
                30));

            DiaryHelper.Log(Constans.diaryTarget,
                string.Format("Canteen has now {0} rations.",
                Rations));
        }
    }
}
