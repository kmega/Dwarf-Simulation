using System;
namespace BFC.Console.AppLogic
{
    public class Randomizer : IRandomizer
    {
        public void ActivateFiremanOrPedofil() 
        {
            Random rand = new Random();

            if (rand.Next(0, 1) == 1)
            {
                _person = new Fireman();
            }
            else _person = new Romantic();
        }
    }

    public interface IRandomizer
    {

    }
}
