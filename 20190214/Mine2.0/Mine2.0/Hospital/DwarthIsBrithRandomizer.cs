using System;

namespace Mine2._0
{
    public class DwarthIsBrithRandomizer : ITryBirth
    {
        public bool TryBirth()
        {
            if (new Random().Next(1, 100) == 1)
                return true;
            return false;
        }
    }
}
