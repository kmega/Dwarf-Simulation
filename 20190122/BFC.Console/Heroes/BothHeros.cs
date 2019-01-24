using System;
using System.Collections.Generic;

namespace BFC.Console.Heroes
{
    public class BothHeros : IBothHeroes
    {
        List<Person> IBothHeroes.ActivateFiremanAndRomanticAtTheSameTime()
        {
            throw new NotImplementedException();
        }
    }

    public interface IBothHeroes
    {
        List<Person> ActivateFiremanAndRomanticAtTheSameTime();
    }
}
