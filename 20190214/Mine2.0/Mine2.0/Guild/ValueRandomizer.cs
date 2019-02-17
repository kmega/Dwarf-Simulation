using System;

namespace Mine2._0
{
    public class ValueRandomizer : IGuildRandomizer
    {
        public decimal SetDirtGoldValue()
        {
            return 5m;
        }

        public decimal SetGoldValue()
        {
            return new Random().Next(10, 21);
        }

        public decimal SetMithrilValue()
        {
            return new Random().Next(15, 26);
        }

        public decimal SetSilverValue()
        {
            return new Random().Next(5, 16);
        }
    }
}