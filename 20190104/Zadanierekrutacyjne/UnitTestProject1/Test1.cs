using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Zadanierekrutacyjne
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TextIsRead()
        {
            string path = @"C:\Users\lysia\source\repos\Zadanierekrutacyjne\Zadanierekrutacyjne\bin\Debug\tea-data.txt";
            ReadtheData reader = new ReadtheData();
            List<string> TeaData = reader.Reader(path);
            string FirstLine = TeaData[0];
            string FirstSentenceExpected = "# Nazwa herbaty, typ herbaty, temperatura parzenia, czas parzenia, specjalne własności";
            Assert.AreEqual(FirstLine,FirstSentenceExpected);


        }
        [TestMethod]
        public void TextIsReversed()
        {
            string path = @"C:\Users\lysia\source\repos\Zadanierekrutacyjne\Zadanierekrutacyjne\bin\Debug\tea-data.txt";

            ReadtheData reader = new ReadtheData();
            List<string> TeaData = reader.Reader(path);
            TeaData.Reverse();
            List<string> TeaData2 = reader.Reader(path);
            for (int i = 0; i < TeaData.Count; i++)
            {
                Assert.AreEqual(TeaData2[TeaData.Count - i-1], TeaData[i]);

            }

        }

    }
}