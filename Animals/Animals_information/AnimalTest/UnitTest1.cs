using Animals_information;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            AnimalObject animalObject = new AnimalObject();
            animalObject.animalName = "Nied�wied�";
            animalObject.eat = WhatEat.mi�so�eny;
            animalObject.whatAnimalDo = WhatAnimalDo.Walk;
            CreateAnimalData createAnimalData = new CreateAnimalData();
            var animals = createAnimalData.Write();
            
        }
    }
}