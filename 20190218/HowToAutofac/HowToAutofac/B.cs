using System;

namespace HowToAutofac
{
    public class B : IB
    {
        private IC _ic;
        private ID _id;
        private IE _ie;

        public B(IC ic, ID id, IE ie)
        {
            _ic = ic;
            _id = id;
            _ie = ie;
        }

        public void Present()
        {
            _ic.Eat();
            _id.Eat();
            _ie.Present();
        }
    }
}
