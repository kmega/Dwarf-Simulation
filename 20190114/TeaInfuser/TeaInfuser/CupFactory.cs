using System;
using System.Collections.Generic;
using System.Text;

namespace TeaInfuser
{
    public class CupFactory : IContainer
    {
        public Cup Pick()
        {
            return new Cup();
        }
    }
}
