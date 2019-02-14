namespace DwarfSimulation
{
    internal interface IBuy
    {
        void Buy(Shop shop, decimal wallet);

        decimal UpdateWallet(decimal wallet);
    }
}