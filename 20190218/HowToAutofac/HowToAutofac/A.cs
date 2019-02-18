namespace HowToAutofac
{
    public class A
    {
        private IB _b;

        public A(IB b)
        {
            _b = b;
        }

        public void Present()
        {
            _b.Present();
        }
    }

}
