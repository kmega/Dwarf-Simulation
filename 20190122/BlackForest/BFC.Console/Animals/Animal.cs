namespace BFC.Console.Animals
{
    public sealed class Animal
    {
        private string _name;
        private string _myVoiceIReact;
        public Animal(string name, AnimalTypes animalType, bool ShouldIBeSaved = true)
        {
            _name = name;
            AnimalType = animalType;
            _myVoiceIReact = null;
        }
        public Animal(string name, AnimalTypes animalType, string voice,bool ShouldIBeSaved = true)
        {
            _name = name;
            AnimalType = animalType;
            _myVoiceIReact = voice;
        }

        public AnimalTypes AnimalType { get; private set; }

        public override string ToString()
        {
            return _name;
        }
        
    }
}