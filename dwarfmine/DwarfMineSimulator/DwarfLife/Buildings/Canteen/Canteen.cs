using System;
namespace DwarfLife.Buildings.Canteen
{
    public class Canteen
    {
        public int Rations { get; set; }

        public Canteen(int rations = 200)
        {
            Rations = rations;
        }

        private bool IsRationsBelow10()
        {
            return Rations < 10;
        }

        private void OrderRations()
        {
            Rations += 30;
        }
    }
}
