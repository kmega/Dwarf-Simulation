using System;
using System.Collections.Generic;
using System.Text;

namespace MockShop
{
    public interface IDateProvider
    {
        DateTime Now();
    }
}
