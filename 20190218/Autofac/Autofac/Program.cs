using Autofac;
using System;

namespace Autofac1
{
    public class A
    {
        IB b;
        public A(IB b)
        {
            this.b = b;
        }
        public void Eat()
        {
            b.Eat();
        }
    }
    public class B : IB
    {
        IC ic;
        ID id;
        IE ie;
        public B(IC ic,ID id,IE ie)
        {
            this.ic = ic;
            this.id = id;
            this.ie = ie;
        }
        public void Eat()
        {
            ic.Eat();
            id.Eat();
            ie.Eat();
        }
    }
    public class C : IC
    {
        public void Eat()
        {
            Console.WriteLine("C");
        }
    }
    public class D : ID
    {
        public void Eat()
        {
            Console.WriteLine("D");
        }
    }
    public class E : IE
    {
        IF iff;
        IG ig;
        public E(IF iff,IG ig)
        {
            this.iff = iff;
            this.ig = ig;
        }
        
        public void Eat()
        {
            iff.Eat();
            ig.Eat();
        }
    }
    public class F : IF
    {
        public void Eat()
        {
            Console.WriteLine("F");
        }
    }
    public class G : IG
    {
        public void Eat()
        {
            Console.WriteLine("G");
        }
    }
    public interface IB
    {
        void Eat();
    }
    public interface IC
    {
        void Eat();
    }
    public interface ID
    {
        void Eat();
    }
    public interface IE
    {
        void Eat();
    }
    public interface IF
    {
        void Eat();
    }
    public interface IG
    {
        void Eat();
    }

    class Program
    {
        static void Main(string[] args)
        {

            //CDFG
            var builder = new ContainerBuilder();
            builder.RegisterType<A>().AsSelf().SingleInstance();
            builder.RegisterType<B>().As<IB>();
            builder.RegisterType<C>().As<IC>();
            builder.RegisterType<D>().As<ID>();
            builder.RegisterType<E>().As<IE>();
            builder.RegisterType<F>().As<IF>();
            builder.RegisterType<G>().As<IG>();


            var h = builder.Build();
            h.Resolve<A>().Eat();
            Console.ReadKey();





        }
    }
}
