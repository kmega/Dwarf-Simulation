using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Dwarf
    {
        public DwarfType dwarfType;
        public IWorkingStrategy workingStrategy;
        public IShoppingStrategy shoppingStrategy;
        private List<Material> _materials = new List<Material>();
    }
}