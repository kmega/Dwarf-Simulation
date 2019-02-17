using System;

namespace Mine2._0
{
    public class MineRandomizer : IRandomizer
    {
        public int GenerateRadnomFromRange()
        {
            return new Random().Next(1, 100);
        }

        public int RandomWorkIteration()
        {
            return new Random().Next(1, 4);
        }
    }
}
