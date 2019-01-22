using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterfaceZnizki
{
    
    interface ICalendarDiscountCalculator
    {
        DateTime dateTime {get;set; }
        double Calculate(DateTime date);
    }
}
