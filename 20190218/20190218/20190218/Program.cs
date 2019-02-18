using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using _20190218.Interfaces;
using _20190218.Objects;


namespace _20190218
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

			var mordor = container.Resolve<A>();
			mordor.JustDoThis();
			System.Console.ReadKey();
		}
	}
}
