namespace ThorinsCompany
{
    public interface IShoppingStrategy
    {
        void Buy(BankAccount dwarfBankAccount,BankAccount bankAccountToTopUp);
    }
}