using System.Collections.Generic;

namespace DwarfSimulation
{
    internal class PrepareSimulation
    {
        Builder _builder = new Builder();

        internal List<Dwarf> PrepareDwarves(int dwarvesNumber)
        {
            return _builder.CreateDwarves(dwarvesNumber);
        }

        internal List<Shaft> PrepareShafts(int shaftsNumber)
        {
            return _builder.CreateShafts(shaftsNumber);
        }
    }
}
