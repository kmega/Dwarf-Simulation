using KarateChop;
using NUnit.Framework;


namespace Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            Chopper chopper = new Chopper();

            int[] blankArr = new int[0];
            chopper.ChopInHalf(5, new int[] { 1, 3, 5, 7 });




            Assert.AreEqual(-1, chopper.ChopInHalf(3, blankArr));
            Assert.AreEqual(-1, chopper.ChopInHalf(3, new int[] { 1 }));
            Assert.AreEqual(0, chopper.ChopInHalf(1, new int[] { 1 }));

            Assert.AreEqual(0, chopper.ChopInHalf(1, new int[] { 1, 3, 5 }));
            Assert.AreEqual(1, chopper.ChopInHalf(3, new int[] { 1, 3, 5 }));
            Assert.AreEqual(2, chopper.ChopInHalf(5, new int[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(0, new int[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(2, new int[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(4, new int[] { 1, 3, 5 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(6, new int[] { 1, 3, 5 }));

            Assert.AreEqual(0, chopper.ChopInHalf(1, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(1, chopper.ChopInHalf(3, new int[] { 1, 3, 5, 7 }));
            
        }

        [Test]
        public void Test2()
        {
            Chopper chopper = new Chopper();

            int[] blankArr = new int[0];
            chopper.ChopInHalf(4, new int[] { 0, 3, 5, 7 }); // returns -1 but in assert shows that it returned -1 and doesn t pass;

            Assert.AreEqual(2, chopper.ChopInHalf(5, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(3, chopper.ChopInHalf(7, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(0, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(2, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(4, new int[] { 0, 3, 5, 7 })); // returns -1 but in assert shows that it returned 1 and doesn t pass;
            Assert.AreEqual(-1, chopper.ChopInHalf(6, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(8, new int[] { 1, 3, 5, 7 }));

        }

        [Test]
        public void Test3()
        {
            Chopper chopper = new Chopper();

            int[] blankArr = new int[0];
            chopper.ChopInHalf(4, new int[] { 0, 3, 5, 7 }); // Same case but here it works

            Assert.AreEqual(-1, chopper.ChopInHalf(4, new int[] { 0, 3, 5, 7 })); // Same case but here it works
            Assert.AreEqual(-1, chopper.ChopInHalf(6, new int[] { 1, 3, 5, 7 }));
            Assert.AreEqual(-1, chopper.ChopInHalf(8, new int[] { 1, 3, 5, 7 }));

        }

        



    }
}