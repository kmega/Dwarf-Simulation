namespace Mine.Dwarfs
{
    public interface IBankAccount
    {
        int Coins { get; }
        void AddCoins(int coinsAmount);
        void WithdrawCoins(int coinsAmount);
        
    }
}
