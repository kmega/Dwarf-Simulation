using System;
using System.Collections.Generic;
using System.Text;

namespace Discounts
{
    public interface IDataBaseProducts
    {
        bool DoesProductExist(string type);
        decimal GivePrice(string type);
    }
}
