using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Example.Assembler;
using Example.Autofac;

namespace ConsoleApp3
{
    class Program
    {
        public static void TestMe()
        {
            // given 
            var backpack = new Backpack();
            backpack.AddPepper(13);
            backpack.AddSalt(13);
            var dwarf = new LazyBastard(backpack:backpack, type:"TheFather", age:18);

            //Alternative
            var lazyBastard = new LazyBastardCreator()
                .WithAge(18)
                .WithType("TheFather")
                .AddPepper(13)
                .AddSalt(13)
                .Build();

            Console.WriteLine(lazyBastard.ToString());
        }
        public static void Main()
        {
            // 1. Stworzyć kontener 
            var builder = new ContainerBuilder();
            // 2. Zarejestrować wszystkie komponenety

            builder.RegisterType<EvilOwca>().As<IEatTable>().SingleInstance();
            builder.RegisterType<Shepard>().As<IShepardable>();
            builder.RegisterType<TheShepardHouse>().AsSelf().AsImplementedInterfaces();
            builder.RegisterType<LazyBastard>().AsSelf();
            // 3. Zbudować 
            var container = builder.Build();
            // 4. Pobrać element główny
            var theShepardHouse = container.Resolve<TheShepardHouse>();
            theShepardHouse.MakeSheepScreem();

            TestMe();
            Console.ReadKey();
        }
    }
}
