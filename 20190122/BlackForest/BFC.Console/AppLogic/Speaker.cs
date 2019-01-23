using BFC.Console.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace BFC.Console.AppLogic
{
    public interface Speaker
    {
        void GenerateSound(Animal animal);
    }
}
