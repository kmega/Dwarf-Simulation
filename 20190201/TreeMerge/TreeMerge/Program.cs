using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            TreesText TreeText = new TreesText();
            TreeFactory factory = new TreeFactory();

            Tree Tree1 = factory.Create(TreeText.Tree1);
            Tree Tree2 = factory.Create(TreeText.Tree2);
            Tree Tree3 = factory.Create(TreeText.Tree3);
            Tree Tree4 = factory.Create(TreeText.Tree4);



            foreach (var item in TreeText.Tree1)
            {
                Console.WriteLine(item);
            }
            foreach (var item in TreeText.Tree2)
            {
                Console.WriteLine(item);
            }
            foreach (var item in TreeText.Tree3)
            {
                Console.WriteLine(item);
            }
            foreach (var item in TreeText.Tree4)
            {
                Console.WriteLine(item);
            }




            Console.ReadKey();
        }
    }
}
