using Autofac;
using System;

namespace HowToAutofac
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<A>().AsSelf();
            builder.RegisterType<B>().As<IB>();
            builder.RegisterType<C>().As<IC>();
            builder.RegisterType<D>().As<ID>();
            builder.RegisterType<E>().As<IE>();
            builder.RegisterType<F>().As<IF>();
            builder.RegisterType<G>().As<IG>();
            var container = builder.Build();
            var item = container.Resolve<A>();
            item.ShowMustGoOn();
            Console.ReadKey();
            


        }
    }
}
