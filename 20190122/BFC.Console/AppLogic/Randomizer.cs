using System;
using BFC.Console.Heroes;

namespace BFC.Console.AppLogic
{
    public class Randomizer : IRandomizer
    {
        public Person ActivateFiremanOrPedofil()
        {
            throw new NotImplementedException();
        }
    }

    public interface IRandomizer
    {
        Person ActivateFiremanOrPedofil();
    }
}
