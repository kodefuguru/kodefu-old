using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kodefu.Tests
{
    [TestClass]
    public class IndexedTests
    {
        [TestMethod]
        public void IndexedTest()
        {
            var strings = new[] {"One", "Two", "Three", "Four"};            
            var indexed = strings.ToIndexed();            
            var ordered = from s in indexed
                          orderby s.Value
                          select s;

            Assert.AreEqual(0, indexed.First().Index);
            Assert.AreEqual("Four", ordered.First().Value);
            Assert.AreEqual(3, ordered.First().Index);
        }
    }
}
