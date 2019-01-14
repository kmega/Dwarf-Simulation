using System;
using System.Collections.Generic;
using System.Text;

namespace TeaInfuser
{
    public class GreenTeaFactory : ITea
    {
        public Tea Pick()
        {
            return new Tea(TeaType.Green, 80, 300);
        }
    }
}
