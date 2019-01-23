using BFC.Console.AppLogic;

namespace BFC.Console.Animals
{
    public sealed class Animal
    {
        private string _name;

        public Animal(string name, AnimalTypes animalType, bool ShouldIBeSaved = true)
        {
            _name = name;
            AnimalType = animalType;
        }

        public AnimalTypes AnimalType { get; private set; }

        public override string ToString()
        {
            return _name;
        }

        public string DoesSitingOnBranch(TimeOfDay timeOfDay)
        {
            string information = _name;

            if (timeOfDay.Equals(TimeOfDay.Night) && AnimalType.Equals(AnimalTypes.Bird)
                || timeOfDay.Equals(TimeOfDay.Day) && AnimalType.Equals(AnimalTypes.Cat)
                || timeOfDay.Equals(TimeOfDay.Fire))
            {
                information += " doesn't sit on the Tree.";
            }
            else
            {
                information += " sit on the Tree.";
            }

            return information;
        }
    }
}