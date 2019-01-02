using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{

    public class StringCalculator
    {
        
        static void Main(string[] args)
        {

            string number = "1,2,3,4,5";
            Console.WriteLine(new Calculator().Add(number));
            Console.ReadKey();

        }

        //public static int Sum0(int result)
        //    {
        //        result = 0;
        //        return result;
        //    }
        //    public static int Sum1(int result)
        //    {
        //        result = 1;
        //        return result;
        //    }
        //    public static int Sum2(int result)
        //    {
        //        result = 2;
        //        return result;
        //    }
    }
}
