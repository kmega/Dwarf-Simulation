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

    }
}