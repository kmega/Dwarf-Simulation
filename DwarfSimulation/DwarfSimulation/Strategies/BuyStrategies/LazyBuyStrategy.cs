namespace DwarfSimulation
{
    internal class LazyBuyStrategy : IBuy
    {
        public void Buy(Shop shop, decimal wallet)
        {
            // Dont buy products
        }

        public decimal UpdateWallet(decimal wallet)
        {
            return wallet;
        }
    }
}
