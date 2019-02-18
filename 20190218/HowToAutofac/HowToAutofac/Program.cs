using System;
using Autofac;

namespace HowToAutofac
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ContainerBuilder();

            builder.RegisterType<A>().AsSelf();
            builder.RegisterType<B>().AsImplementedInterfaces();
            builder.RegisterType<C>().AsImplementedInterfaces();
            builder.RegisterType<D>().AsImplementedInterfaces();
            builder.RegisterType<E>().AsImplementedInterfaces();
            builder.RegisterType<F>().AsImplementedInterfaces();
            builder.RegisterType<G>().AsImplementedInterfaces();

            var container = builder.Build();

            var eatable = container.Resolve<A>();

            eatable.Present();

            Console.ReadKey();
        }
    }

}
