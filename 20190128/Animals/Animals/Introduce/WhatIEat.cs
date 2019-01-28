using System;
using System.Collections.Generic;
using System.Text;

namespace Animals.Introduce
{
    public class WhatIEat : IIntroduce
    {
        public void IntroduceYourself(string SomethingToSay)
        {
            switch (SomethingToSay)
            {

                case "wszystkożerny":

                    Console.WriteLine("Jestem wszystkożerny.");
                        break;

                case "mięsożerny":
                    Console.WriteLine("jestem mięsożerny.");
                    break;

                case "roślinożerny":
                    Console.WriteLine("Jestem roślinożerny");
                    break;
                default:
                    Console.WriteLine("Poszczę.");
                    break;
            }
        }
    }
}
