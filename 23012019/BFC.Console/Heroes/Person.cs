using System.Collections.Generic;
using BFC.Console.Animals;

namespace BFC.Console.Heroes
{
    public interface Person
    {
        void RescueAnimals(IList<Animal> branch);
    }
}
