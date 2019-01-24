using System;
using System.Collections.Generic;
using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Heroes;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.FiremanAndRomanticComeToWoodAtTheSameTime
{
    [TestFixture]
    public class WhenBothComeAtTheSameTimeRomanticGrabsChildBeforeFireman
    {
        private BlackForest _blackForest;
        private Mock<IOutputWritter> _presenter;
        private Mock<IBothHeroes> _BothHeroes;

        [SetUp]
        public void Setup()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);
            _BothHeroes = new Mock<IBothHeroes>();
        }

        [Test]
        public void AndChildIsOnBranchRomanticKidnaps()
        {
            //gievn
            var animals = new[] { AnimalTypes.Child };
            _BothHeroes.Setup(x => x.ActivateFiremanAndRomanticAtTheSameTime())
                                    .Returns(new List<Person> { new Romantic(), new Fireman()});
            _blackForest.SitOnTheTree(animals);

            //when
            _blackForest.ActivateFiremanAndRomantic(_BothHeroes.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            //then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
            _presenter.Verify(i => i.WriteLine("Nobody will be rescued by Fireman."));
        }

        [Test]
        public void AndChildAndCatIsOnBranchRomanticKidnaps()
        {
            //gievn
            var animals = new[] { AnimalTypes.Child, AnimalTypes.Cat };
            _BothHeroes.Setup(x => x.ActivateFiremanAndRomanticAtTheSameTime())
                                    .Returns(new List<Person> { new Romantic(), new Fireman() });
            _blackForest.SetTimeOfDay(TimeOfDay.Night);
            _blackForest.SitOnTheTree(animals);

            //when
            _blackForest.ActivateFiremanAndRomantic(_BothHeroes.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            //then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
            _presenter.Verify(i => i.WriteLine("Child, Cat will be rescued by Fireman."));
        }

        [Test]
        public void AndCatIsOnBranchRescuedByFireman()
        {
            //gievn
            var animals = new[] { AnimalTypes.Cat };
            _BothHeroes.Setup(x => x.ActivateFiremanAndRomanticAtTheSameTime())
                                    .Returns(new List<Person> { new Romantic(), new Fireman() });
            _blackForest.SetTimeOfDay(TimeOfDay.Night);
            _blackForest.SitOnTheTree(animals);

            //when
            _blackForest.ActivateFiremanAndRomantic(_BothHeroes.Object);
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

            //then
            _presenter.Verify(i => i.WriteLine("Nobody will be rescued by Romantic."));
            _presenter.Verify(i => i.WriteLine("Child, Cat will be rescued by Fireman."));
        }
    }
}
