using NUnit.Framework;
using IntroduceAnimal;

namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void T01_CreateBear()
        {
            //given
            AnimalFactory factory = new AnimalFactory();
            AnimalTypes name = AnimalTypes.Bear;
            string movement = "walking";
            string eating = "omnivorous";

            var bear = factory.CreateAnimal(name);

            Assert.AreEqual(bear.GetName(), name);
            Assert.AreEqual(bear.GetMovementStyle(), movement);
            Assert.AreEqual(bear.GetEatingStyle(), eating);
        }

        [Test]
        public void T02_CreatePelican()
        {
            //given
            AnimalFactory factory = new AnimalFactory();
            AnimalTypes name = AnimalTypes.Pelican;
            string movement = "flying";
            string eating = "ichthyophagous";

            var pelican = factory.CreateAnimal(name);

            Assert.AreEqual(pelican.GetName(), name);
            Assert.AreEqual(pelican.GetMovementStyle(), movement);
            Assert.AreEqual(pelican.GetEatingStyle(), eating);
        }

        [Test]
        public void T03_CreateVegetarian()
        {
            //given
            AnimalFactory factory = new AnimalFactory();
            AnimalTypes name = AnimalTypes.Vegetarian;
            string movement = "flying";
            string eating = "herbivorous";

            var vegetarian = factory.CreateAnimal(name);

            Assert.AreEqual(vegetarian.GetName(), name);
            Assert.AreEqual(vegetarian.GetMovementStyle(), movement);
            Assert.AreEqual(vegetarian.GetEatingStyle(), eating);
        }

        [Test]
        public void T04_CreateKillerWhale()
        {
            //given
            AnimalFactory factory = new AnimalFactory();
            AnimalTypes name = AnimalTypes.Bear;
            string movement = "swimming";
            string eating = "carnivorous";

            var killerWhale = factory.CreateAnimal(name);

            Assert.AreEqual(killerWhale.GetName(), name);
            Assert.AreEqual(killerWhale.GetMovementStyle(), movement);
            Assert.AreEqual(killerWhale.GetEatingStyle(), eating);
        }

        //[Test]
        //public void T05_AnimalCanIntroduceItself()
        //{
        //    //given

        //    Mock factory = new Mock();

        //    AnimalFactory factory = new AnimalFactory();
        //    string name = "Killer Whale";
        //    string movement = "swimming";
        //    string eating = "carnivorous";

        //    var killerWhale = factory.CreateAnimal(name, movement, eating);

        //    Assert.AreEqual(killerWhale.GetName(), name);
        //    Assert.AreEqual(killerWhale.GetMovementStyle(), movement);
        //    Assert.AreEqual(killerWhale.GetEatingStyle(), eating);
        //}
    }
}