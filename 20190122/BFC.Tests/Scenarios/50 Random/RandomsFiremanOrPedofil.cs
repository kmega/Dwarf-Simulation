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
    public class RandomsFiremanOrPedofil
    {
        [Test]
        public void AndChildAndCatSitOnTheBranchThenItWillBeRescued()
        {
            Mock<IOutputWritter> _presenter;
            BlackForest _blackForest;
            // given 
            var animal = new[] { AnimalTypes.Child };
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);

            var mockRandomizer = new Mock<IRandomizer>();
            mockRandomizer.Setup(x => x.ActivateFiremanOrPedofil()).Returns(new Fireman());

            _blackForest.SitOnTheTree(animal);
            // when 
            _blackForest.RandomRomanticOrFireman(mockRandomizer.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);


            // then
            _presenter.Verify(i => i.WriteLine("Child, Cat will be rescued by Fireman."));
        }
    }
}
