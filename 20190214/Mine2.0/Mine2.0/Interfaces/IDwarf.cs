using System.Collections.Generic;

namespace Mine2._0
{
    public interface IDwarf : IWork, IMoneyOperator, IBuy
    { 
        E_DwarfType _dwarfType { get; }
        bool _isAlive { get; set; }
        IWorkStrategy _workStrategy { get; set; }
        IBuyStrategy _buyStrategy { get; set; }
        new List<E_Minerals> ShowBackpack();
    }
}
