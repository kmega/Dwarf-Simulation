using System;
using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Random
{
    [TestFixture]
    public class WhenFiremanIsRandomized
    {
        private Mock<IOutputWritter> _presenter;
        private BlackForest _blackForest;
        private Mock<IRandomizer> _mockRandomizer;

        [SetUp]
        public void Setup()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);
            _mockRandomizer = new Mock<IRandomizer>();
        }

        [Test]
        public void AndChildSitOnTheBranchThenItWillBeRescued()
        {
            // given 
            var animal = new[] { AnimalTypes.Child };
            _mockRandomizer.Setup(x => x.ActivateFiremanOrPedofil()).Returns(new Fireman());
            _blackForest.SitOnTheTree(animal);

            // when 
            _blackForest.RandomRomanticOrFireman(_mockRandomizer.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child, Cat will be rescued by Fireman."));
        }

        [Test]
        public void AndChildAndCatSitOnTheBranchThenItWillBeRescued()
        {
            // given 
            var animal = new[] { AnimalTypes.Child, AnimalTypes.Cat };
            _mockRandomizer.Setup(x => x.ActivateFiremanOrPedofil()).Returns(new Fireman());
            _blackForest.SitOnTheTree(animal);

            // when 
            _blackForest.RandomRomanticOrFireman(_mockRandomizer.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            // then
            _presenter.Verify(i => i.WriteLine("Child, Cat will be rescued by Fireman."));
        }
    }
}
