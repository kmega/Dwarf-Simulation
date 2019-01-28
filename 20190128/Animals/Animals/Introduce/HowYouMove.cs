using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Introduce
{
    public class HowYouMove : IIntroduce
    {
        public void IntroduceYourself(string SomethingToSay)
        {
            switch (SomethingToSay)
            {

                case "chodzi":

                    Console.WriteLine("Chodzę.")
                        break;

                case "lata":
                    Console.WriteLine("Latam.");
                    break;

                case "pływam":
                    Console.WriteLine("Pływamm");
                    break;
                default:
                    Console.WriteLine("Lenię się.");
                    break;
            }
        }
    }
}
