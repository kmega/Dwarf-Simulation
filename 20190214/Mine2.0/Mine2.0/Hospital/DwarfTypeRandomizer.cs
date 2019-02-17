using System;
using System.Linq;

namespace Mine2._0
{
    public class DwarfTypeRandomizer : IDwarfTypeRandomizer
    {
        public E_DwarfType GetRandomDwarfType()
        {
            var type = new Random().Next(1, 101);

            if (Enumerable.Range(1, 33).Contains(type))
            {
                return E_DwarfType.Sluggard;
            }
            else if (Enumerable.Range(33, 33).Contains(type))
            {
                return E_DwarfType.Father;
            }
            else if (Enumerable.Range(66, 33).Contains(type))
            {
                return E_DwarfType.Single;
            }

            return E_DwarfType.Sabouter;
        }
    }
}
