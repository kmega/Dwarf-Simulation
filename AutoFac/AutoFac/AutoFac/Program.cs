using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutoFaca
{
    class Program
    {
        static void Main(string[] args)
        {
            //A ->IB -> B -> IC, ID, IE
            //IC -> C
            //ID -> D
            //IE - IF, IG
            //IF -> F
            //IG -> G
            var builder = new ContainerBuilder();
        }
        interface IB
        {

        }
        interface IG
        {

        }
        interface IF
        {

        }
        interface IE
        {

        }
        interface IC
        {

        }
        interface ID
        {

        }
        class A : IB
        {
            public A()
            {

            }
        }
        class B : IC, ID, IE
        {
            public B()
            {

            }
        }
        class E : IF, IG
        {
            public E()
            {

            }
        }
        class C
        {
            public C()
            {

            }
        }
        class D
        {
            public D()
            {

            }
        }
        class F
        {
            public F()
            {

            }
        }
        class G
        {
            public G()
            {

            }
        }
    }
}
