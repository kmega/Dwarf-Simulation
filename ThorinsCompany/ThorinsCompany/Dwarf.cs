using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Dwarf
    {
        public DwarfType dwarfType;
        public IWorkingStrategy workingStrategy;
        public IShoppingStrategy shoppingStrategy;
        private Dictionary<Material, int> _materials = new Dictionary<Material, int>();
    }
}