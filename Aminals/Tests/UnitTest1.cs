using NUnit.Framework;
using Aminals;

namespace Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void BearSayHi()
		{
			//given
			AnimalsFactory animal = new AnimalsFactory();
			IAnimal bear = animal.CreateAnimal(Animals.Bear);

			//when
			IAnimal expected = new Bear();

			//then
			Assert.AreEqual();
		}
	}
}