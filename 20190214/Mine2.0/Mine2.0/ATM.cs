using System.Collections.Generic;

namespace Mine2._0
{
    public class ATM
    {
        public void TransferDailyWageToOverall(List<IMoneyOperator> dwarfs)
        {
            foreach (var dwarf in dwarfs)
            {
                var temp = dwarf._bankAccount._dailyIncome;
                dwarf._bankAccount._dailyIncome = 0;
                dwarf._bankAccount._overallIncome += temp;
            }
        }
    }
}