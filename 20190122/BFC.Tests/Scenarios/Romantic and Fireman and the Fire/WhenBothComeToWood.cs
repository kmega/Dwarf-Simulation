using BFC.Console.Animals;
using BFC.Console.AppLogic;
using BFC.Console.Presentation;
using Moq;
using NUnit.Framework;

namespace BFC.Tests.Scenarios.Romantic_and_Fireman_and_the_Fire
{
    [TestFixture]
    public class WhenBothComeToWood
    {
        private BlackForest _blackForest;

        private Mock<IOutputWritter> _presenter;

        [SetUp]
        public void SetUp()
        {
            _presenter = new Mock<IOutputWritter>();
            _blackForest = new BlackForest(_presenter.Object);

        }

        [Test]
       public void RomanticShowBeforeFireman()
        {
            // given 
            var animals = new[] { AnimalTypes.Child, AnimalTypes.Cat };
            _blackForest.SetTimeOfDay(TimeOfDay.Night);
            _blackForest.SitOnTheTree(animals);

            // when 
            _blackForest.SetTimeOfDay(TimeOfDay.Fire);

          
            // then
            _presenter.Verify(i => i.WriteLine("Child will be rescued by Romantic."));
         
            _presenter.Verify(i => i.WriteLine("Cat will be rescued by Fireman."));
        }







    }
}
