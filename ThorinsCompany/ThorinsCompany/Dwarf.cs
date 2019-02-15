using System.Collections.Generic;

namespace ThorinsCompany
{
    public class Dwarf
    {
        public readonly int accountID;
        public DwarfType DwarfType;
        public IWorkingStrategy WorkingStrategy;
        public IShoppingStrategy ShoppingStrategy;
        private List<Material> _materials = new List<Material>();
        private BankAccount _bankAccount;

        public Dwarf(DwarfType dwarfType, IShoppingStrategy shoppingStrategy, IWorkingStrategy workingStrategy)
        {
            DwarfType = dwarfType;
            ShoppingStrategy = shoppingStrategy;
            WorkingStrategy = workingStrategy;
            accountID = IDCreator.GetUniqueID();
            _bankAccount = AccountCreator.CreateNewAccount(accountID);

        }

        public List<Material> ShowDiggedMaterials() => _materials;
        public BankAccount GetBankAccount() => _bankAccount;
    }
}