using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterfaceZnizki
{
    public interface IDiscount_Calc
    {
        double Calculate(ProductCalc.Type type);
        DateTime dateTime { get; set; }
        double Calculate(DateTime dateTime);
    }
}
