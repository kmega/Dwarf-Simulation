using System;
using System.Collections.Generic;
using System.Text;

namespace Mine
{
    class Bank : IBankAccount
    {
        private int _coins;
        public int Coins
        {
            get { return _coins; }
            private set
            {
                if (_coins + value < 0)
                    throw new ArgumentOutOfRangeException();
                _coins = value;
            }
        }

        public void AddCoins(int coinsAmount)
        {
            Coins += coinsAmount;
        }

        public void WithdrawCoins(int coinsAmount)
        {
            Coins -= coinsAmount;
        }
    }
}
