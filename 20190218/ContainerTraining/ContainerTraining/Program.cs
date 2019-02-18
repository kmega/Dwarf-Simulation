using Autofac;
using System;

namespace ContainerTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<A>().AsSelf();
            builder.RegisterType<B>().AsImplementedInterfaces();
            builder.RegisterType<C>().AsImplementedInterfaces();
            builder.RegisterType<D>().AsImplementedInterfaces();
            builder.RegisterType<E>().AsImplementedInterfaces();
            builder.RegisterType<F>().AsImplementedInterfaces();
            builder.RegisterType<G>().AsImplementedInterfaces();

            var container = builder.Build();

            container.Resolve<A>().Eat();



            Console.ReadKey();

        }
    }


    class A
    {
        private IB _b;

        public A(IB b)
        {
            _b = b;
        }

        public void Eat()
        {
            _b.Eat();
        }
    }

    class B : IB
    {
        private IC _c;
        private ID _d;
        private IE _e;

        public B(IC c, ID d, IE e)
        {
            _c = c;
            _d = d;
            _e=e;

        }

        public void Eat()
        {
            _c.Eat();
            _d.Eat();
            _e.Eat();
        }
    }
    interface IB
    {
        void Eat();
    }

    interface IC
    {
        void Eat();
    }

    interface ID
    {
        void Eat();
    }

    interface IE
    {
        void Eat();
    }

    class C : IC
    {
        public void Eat()
        {
            Console.WriteLine("C");
        }
    }

    class D : ID
    {
        public void Eat()
        {
            Console.WriteLine("D");
        }
    }

    class E : IE
    {
        private IF _f;
        private IG _g;

        public E(IF f, IG g)
        {
            _f=f;
            _g=g;
        }
        public void Eat()
        {
            _f.Eat();
            _g.Eat();
        }
    }

    interface IF
    {
        void Eat();
    }

    interface IG
    {
        void Eat();
    }

    class F : IF
    {
        public void Eat()
        {
            Console.WriteLine("F");
        }
    }

    class G : IG
    {
        public void Eat()
        {
            Console.WriteLine("G");
        }
    }
}
