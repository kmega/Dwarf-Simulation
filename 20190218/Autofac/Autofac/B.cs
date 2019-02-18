using System;
using System.Collections.Generic;
using System.Text;

namespace HowToAutofac
{
    public class B : IB
    {
        IC C;
        ID D;
        IE E;

        public void It()
        {
            throw new NotImplementedException();
        }


        public B(IC c, ID d, IE e)
        {
            C = c;
            D = d;
            E = e;
        }
    }

}
