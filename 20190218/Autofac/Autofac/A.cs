using System;
using System.Collections.Generic;
using System.Text;

namespace HowToAutofac
{
    public class A
    {
        IB B;
        public A(IB b)
        {
            B = b;
        }
    }
}
