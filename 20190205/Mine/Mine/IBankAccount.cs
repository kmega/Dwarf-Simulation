using System;
using System.Collections.Generic;
using System.Text;

namespace Mine
{
    public interface IBankAccount
    {
        int Coins { get; }
        void AddCoins(int coinsAmount);
        void WithdrawCoins(int coinsAmount);
        
    }
}
