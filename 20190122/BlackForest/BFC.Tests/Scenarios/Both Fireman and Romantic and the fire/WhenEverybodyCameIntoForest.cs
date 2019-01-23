using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using BFC.Console.Heroes;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.BothFiremanandRomanticandthefire
{
    [TestFixture]
    public class WhenEverybodyCameIntoForest
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;
        private Mock<IProbablilityOfRomantic> _randomRomantic;

        [SetUp]
        public void SetUp()
        {
            _presenter = new Mock<IOutputWritter>();
            _randomRomantic = new Mock<IProbablilityOfRomantic>();
            _randomRomantic.Setup(i => i.Draw()).Returns(true);
            _blackForest = new BlackForest(_presenter.Object);
            _blackForest.ActivateFireman();
        }

        [Test]
        public void AndChildWillBeRescuedByRomantic()
        {
            // given 
            var animals = new[] { AnimalTypes.Child };
            _blackForest.TryToActivateRomantic(_randomRomantic.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Day);
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
        }
        [Test]
        public void AndChildWillBeRescuedByRomanticAndCatWillBeRescuedByFiremen()
        {
            // given 
            var animals = new[] { AnimalTypes.Child, AnimalTypes.Cat };
            _blackForest.TryToActivateRomantic(_randomRomantic.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Night);
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
            _presenter.Verify(i => i.WriteLine("Cat will be rescued by Fireman."));
        }
        [Test]
        public void AndChildWillBeRescuedByRomanticAndBirdSavedBySpeaker()
        {
            // given 
            var animals = new[] { AnimalTypes.Child, AnimalTypes.Bird };
            _blackForest.TryToActivateRomantic(_randomRomantic.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Day);
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
            _presenter.Verify(i => i.WriteLine("Fireman generated alarm sound."));
        }
    }
}
