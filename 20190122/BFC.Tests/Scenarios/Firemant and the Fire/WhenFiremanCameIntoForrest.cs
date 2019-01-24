using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Firemant_and_the_Fire
{
    [TestFixture]
    public class WhenFiremanCameIntoForrest
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;

        [SetUp]
        public void SetUp()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);
            _blackForest.ActivateFireman();
        }

        [Test]
        public void AndChildAndCatSitOnTheBranchThenItWillBeRescued()
        {
            // given 
            var animals = new[] { AnimalTypes.Child, AnimalTypes.Cat };
            _blackForest.SetTimeOfDay(TimeOfDay.Night);
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child, Cat will be rescued by Fireman."));
        }

        [Test]
        public void AndBirdSitOnTheBranchThenItWillNotBeRescued()
        {
            // given 
            var animals = new[] { AnimalTypes.Bird };
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Nobody will be rescued by Fireman."));
        }


        [Test]
        public void AndBirdSitOnTheBranchThenFiremanWillGenerateSound()
        {
            // given 
            var animals = new[] { AnimalTypes.Bird };
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Fireman generated alarm sound."));
        }
    }
}
