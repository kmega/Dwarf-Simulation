using System;

namespace HowToAutofac
{
    public class E : IE
    {
        private IF _if;
        private IG _ig;

        public E(IF @if, IG ig)
        {
            _if = @if;
            _ig = ig;
        }

        public void Present()
        {
            _if.Eat();
            _ig.Eat();
        }
    }

}
