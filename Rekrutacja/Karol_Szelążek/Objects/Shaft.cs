using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class Shaft
    {
        internal bool Collapsed = false;
        internal int MaxInside = 5;
        internal IWork WorkAction;
        internal List<Dwarf> Miners = new List<Dwarf>();

        public Shaft()
        {
            Collapsed = false;
            MaxInside = 5;
            WorkAction = new DefaultWorkStrategy();
        }
    }
}