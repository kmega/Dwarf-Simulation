using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DwarfsTown;
using System.Collections.Generic;

namespace DwarfsTownTests
{
    [TestClass]
    public class BarTest
    {
        Bar bar = new Bar();
        List<Dwarf> DwarftList = new List<Dwarf>();

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ReturnExceptionWhenDwarftCoutIsZero()
        {
         
            bar.FeedDwarfs(DwarftList);           
        }

        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ReturnExceptionWhenFoodsEnd()
        {
            bar.feed = 9;
            DwarftList.Add(new Dwarf(TypeEnum.Father));
            bar.FeedDwarfs(DwarftList);
            
        }
            
        
    }
}
