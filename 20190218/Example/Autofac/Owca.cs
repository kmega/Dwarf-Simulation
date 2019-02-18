using System;

namespace Example.Autofac
{
    public class Owca: IEatTable
    {
        private string _name;

        public Owca(string name)
        {
            _name = name;
        }

        public void Eat()
        {
            Console.WriteLine("Beee my name {0}", _name);
        }
    }
}