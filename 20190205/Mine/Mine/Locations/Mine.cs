using Mine.Locations.Interfaces;

namespace Mine.Locations
{
    public sealed class Mine : IMine
    {
        private static readonly Mine _instance = new Mine();

        public static Mine Instance
        {
            get
            {
                return _instance;
            }
        }

    }
}
