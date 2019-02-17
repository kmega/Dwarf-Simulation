using System.Collections.Generic;

namespace Mine2._0
{
    public interface IMoneyOperator
    {
        PersonalBankAccount _bankAccount { get; set; }
        List<E_Minerals> _backpack { get; set; }
    }
}
