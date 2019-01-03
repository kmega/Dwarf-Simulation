using System;
using happypathpiotrekalicja;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject1
{
    [TestClass]
    public class Task1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var Getter = new Operations();
            string komciurPath = @"C:\Users\lysia\cUserslysia.ssh\primary\20181218\cybermagic\karty-postaci\1807-fryderyk-komciur.md";

            string name = Getter.ReturnName(komciurPath); 
            int time = Getter.ReturnTime(komciurPath);

            int expectedTime = 23;
            string expectedName = "Fryderyk Komciur";

            Assert.AreEqual(time, expectedTime);
            Assert.AreEqual(name, expectedName);
        }
    }
}
