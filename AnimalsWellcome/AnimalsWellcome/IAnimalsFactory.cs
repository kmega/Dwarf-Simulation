using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsWellcome
{
    interface IAnimalsFactory
    {
         Animal Create(string type, Enums.Meal meal, Enums.Attributes attribute);
    }
}
