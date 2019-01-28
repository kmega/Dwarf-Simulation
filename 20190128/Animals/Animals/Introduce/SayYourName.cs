using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Introduce
{
   public class SayYourName : IIntroduce
    {
        public void IntroduceYourself(string SomethingToSay)
        {
            Console.WriteLine("Jestem {0}.", SomethingToSay);
        }
    }
}
