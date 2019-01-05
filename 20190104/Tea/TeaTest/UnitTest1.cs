using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tea;

namespace TeaTest
{
    [TestClass]
    public class UnitTest1
    {

        
        [TestMethod]
        public void IsReverse()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)
            };

            tealist.Reverse();

            Assert.IsTrue(tealist[0].name == "zzzherbata");
            Assert.IsTrue(tealist[1].name == "innaHerbata");
            Assert.IsTrue(tealist[2].name == "herbata");


        }

        [TestMethod]
        public void IsSort()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)
            };

            tealist = tealist.OrderBy(x => x.type).ToList();

            Assert.IsTrue(tealist[0].type == "inaczejkolorowa");
            Assert.IsTrue(tealist[1].type == "kolorowa");
            Assert.IsTrue(tealist[2].type == "zkolorem");


        }


        [TestMethod]
        public void isYuckyTemp()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)

                   
            };
           string result= new PrepareTea().tempcheck(110, tealist[0].temp).ToString();

            Assert.AreEqual("yucky", result);


        }

        [TestMethod]
        public void isWeakTemp()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)


            };
            string result = new PrepareTea().tempcheck(80, tealist[0].temp).ToString();

            Assert.AreEqual("weak", result);


        }

        [TestMethod]
        public void isWeakTime()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)


            };
            string result = new PrepareTea().timecheck(200, tealist[0].temp).ToString();

            Assert.AreEqual("weak", result);


        }
        [TestMethod]
        public void isYuckyTime()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)


            };
            string result = new PrepareTea().timecheck(400, tealist[0].time).ToString();

            Assert.AreEqual("yucky", result);


        }

        [TestMethod]
        public void isYuckyWhenOneIsWeak()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)


            };
            string result = new PrepareTea().TeaMaker(80, tealist[0].temp, 350, tealist[0].time).ToString();
            Assert.AreEqual("yucky", result);


        }

        [TestMethod]
        public void isPerfect()
        {
            TeaBuilder tb = new TeaBuilder();

            List<TeaObj> tealist = new List<TeaObj>()
            {
                tb.AddTea(new FakeTea().fakeTea1),
                  tb.AddTea(new FakeTea().fakeTea2),
                    tb.AddTea(new FakeTea().fakeTea3)


            };
            string result = new PrepareTea().TeaMaker(96, tealist[0].temp,300, tealist[0].time).ToString();
            Assert.AreEqual("perfect", result);


        }








    }
}
