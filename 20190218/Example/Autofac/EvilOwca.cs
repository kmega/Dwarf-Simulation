using System;

namespace Example.Autofac
{
    public class EvilOwca : IEatTable
    {
        public EvilOwca()
        {
            Console.WriteLine("EvilOwca Ctor");
        }
        public void Eat()
        {
            Console.WriteLine("Donde esta la biblioteca?");
        }
    }
}