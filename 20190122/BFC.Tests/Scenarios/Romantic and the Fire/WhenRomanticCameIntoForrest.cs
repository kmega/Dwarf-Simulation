using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Romantic_and_the_Fire
{
    [TestFixture]
    public class WhenRomanticCameIntoForrest
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;

        [SetUp]
        public void SetUp()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);
            _blackForest.ActivateRomantic();
        }

        [Test]
        public void AndChildSitOnTheBranchThenItWillBeRescued()
        {
            // given 
            var animals = new[] { AnimalTypes.Child , AnimalTypes.Cat};
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
        }

        [Test]
        public void AndChildSitOnTheBranchDuringFireThenItWillNotBeRescued()
        {
            // given 
            var animals = new[] { AnimalTypes.Child };
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // when 
            _blackForest.SitOnTheTree(animals);

            // then
            _presenter.Verify(i => i.WriteLine("Nobody will be rescued by Romantic."));
        }
    }
}
