using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Animals_in_The_Wood
{
    [TestFixture]
    public class WhenAnimalCameInTheForest
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;

        [SetUp]
        public void SetUp()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);
        }

        [TestCase(AnimalTypes.Cat, TimeOfDay.Day, "Cat doesn't sit on the Tree.")]
        [TestCase(AnimalTypes.Cat, TimeOfDay.Night, "Cat sit on the Tree.")]
        [TestCase(AnimalTypes.Cat, TimeOfDay.Fire, "Cat doesn't sit on the Tree.")]
        [TestCase(AnimalTypes.Child, TimeOfDay.Day, "Child sit on the Tree.")]
        [TestCase(AnimalTypes.Child, TimeOfDay.Night, "Child sit on the Tree.")]
        [TestCase(AnimalTypes.Child, TimeOfDay.Fire, "Child doesn't sit on the Tree.")]
        [TestCase(AnimalTypes.Bird, TimeOfDay.Day, "Bird sit on the Tree.")]
        [TestCase(AnimalTypes.Bird, TimeOfDay.Night, "Bird doesn't sit on the Tree.")]
        [TestCase(AnimalTypes.Bird, TimeOfDay.Fire, "Bird doesn't sit on the Tree.")]
        public void ThenProperInformationShouldBeDisplayed(AnimalTypes animalType, TimeOfDay timeOfDay, string information)
        {
            // given
            _blackForest.SetTimeOfDay(timeOfDay);

            // when
            _blackForest.SitOnTheTree(animalType);

            // then
            _presenter.Verify(i => i.WriteLine(information));
        }

        [Test]
        public void AndTimeOfDayIsFireThenNoAnimalsShouldSitOnTree()
        {
            // given
            var animals = new[] { AnimalTypes.Bird, AnimalTypes.Cat, AnimalTypes.Bird };
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // when
            _blackForest.SitOnTheTree(animals);

            // then
            _presenter.Verify(i => i.WriteLine("Bird, Cat, Child doesn't sit on the Tree"));
        }
    }
}