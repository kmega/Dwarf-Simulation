using BFC.Console.Animals;
using BFC.Console.Heroes;
using NUnit.Framework;

namespace BFC.Tests.Heroes
{
    [TestFixture]
    public class RomanticTests
    {
        private readonly Romantic _romantic = new Romantic();
        [Test]
        public void ShouldBeAbleToRescueAnimalFromBranchWhenTimeOfDayIsFireAndAnimalTypeIsChild()
        {
            // given 
            var branch = BranchHelper.PutAnimalOnBranch(AnimalTypes.Child);

            // when 
            _romantic.RescuAnimals(branch);

            // then
            const int expected = 0;
            Assert.That(branch.Count, Is.EqualTo(expected));
        }

        [TestCase(AnimalTypes.Cat)]
        [TestCase(AnimalTypes.Bird)]
        public void ShouldNotTryToRescueAnimalFromBranchWhenTimeOfDayIsFireAndAnimalTypeIsDifferentFromChild(AnimalTypes animalTypes)
        {
            // given 
            var branch = BranchHelper.PutAnimalOnBranch(animalTypes);

            // when 
            _romantic.RescuAnimals(branch);

            // then
            const int expected = 0;
            Assert.That(branch.Count, Is.Not.EqualTo(expected));
        }
       
    } 
}
