using System;
using System.Collections.Generic;
using System.Text;

namespace TeaInfuser
{
    public class static Shelf
    {
        public static Cup Take(IContainer container)
        {
            return container.Pick();
        }
    }
}
