using BFC.Console.Animals;
using BFC.Console.Heroes;
using NUnit.Framework;

namespace BFC.Tests.Heroes
{
    [TestFixture]
    public class FiremanTests
    {
        private readonly Fireman _fireman = new Fireman();
        [Test]
        public void ShouldBeAbleToRescueAnimalFromBranchWhenTimeOfDayIsFireAndAnimalTypeIsChild()
        {
			// given 
			var branch = BranchHelper.PutAnimalOnBranch(AnimalTypes.Child);

            // when 
            _fireman.RescuAnimals(branch);

            // then
            const int expected = 0;
            Assert.That(branch.Count, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldBeAbleToRescueAnimalFromBranchWhenTimeOfDayIsFireAndAnimalTypeIsCat()
        {
            // given 
            var branch = BranchHelper.PutAnimalOnBranch(AnimalTypes.Cat);

            // when 
            _fireman.RescuAnimals(branch);

            // then
            const int expected = 0;
            Assert.That(branch.Count, Is.EqualTo(expected));
        }

        [Test]
        public void ShouldNotBeAbleToRescueAnimalFromBranchWhenTimeOfDayIsFireAndAnimalTypeIsBird()
        {
            // given 
            var branch = BranchHelper.PutAnimalOnBranch(AnimalTypes.Bird);

            // when 
            _fireman.RescuAnimals(branch);

            // then
            const int expected = 1;
            Assert.That(branch.Count, Is.EqualTo(expected));
        }
    }
}
