using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Dwarf
    {
        public readonly int accountID;
        public DwarfType DwarfType;
        public IWorkingStrategy WorkingStrategy;
        public IShoppingStrategy ShoppingStrategy;
        private Dictionary<Material, int> _materials = new Dictionary<Material, int>();

        public Dwarf(DwarfType dwarfType, IShoppingStrategy shoppingStrategy, IWorkingStrategy workingStrategy)
        {
            DwarfType = dwarfType;
            ShoppingStrategy = shoppingStrategy;
            WorkingStrategy = workingStrategy;
            accountID = AccountCreator.CreateNewAccountWithUniqueID();

        }
    }
}