namespace Mine2._0
{
    public class PersonalBankAccount
    {
        public decimal _overallIncome { get; set; }
        public decimal _dailyIncome { get; set; }

        public PersonalBankAccount()
        {
            _overallIncome = 0m;
            _dailyIncome = 0m;
        }
    }
}