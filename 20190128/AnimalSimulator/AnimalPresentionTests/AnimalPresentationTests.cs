using AnimalSimulator;
using AnimalSimulator.Animals;
using AnimalSimulator.Enums;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private Mock<IOutputWritter> presenter;
        [SetUp]
        public void Setup()
        {
            presenter = new Mock<IOutputWritter>();
        }

        [Test]
        public void ShouldCreateBearAndItShouldPresentItself()
        {
            //given:
            var bear = AnimalFactory.Create(AnimalType.Bear);
            //when
            AnimalPresenter.PresentYourself(bear);
            //then
            Verify
        }
    }
}