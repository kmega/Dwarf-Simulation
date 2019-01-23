using System;
using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Random
{
    [TestFixture]
    public class RandomsFiremanOrPedofil
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;
        private Mock<IRandomizer> _ranodmizer;

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
    }
}
