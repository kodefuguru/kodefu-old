namespace Kodefu.Tests
{
    using System;
    using Kodefu;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MaybeTests
    {
        [TestMethod]
        public void NullEnum()
        {
            Assert.IsNull(String.Empty.Maybe<TypeCode>());
        }

        [TestMethod]
        public void ValidEnum()
        {
            Assert.AreEqual(TypeCode.Char, "Char".Maybe<TypeCode>());
        }

        [TestMethod]
        public void NullInt()
        {
            Assert.IsNull(String.Empty.Maybe<int>());
        }

        [TestMethod]
        public void ValidInt()
        {
            Assert.AreEqual(42, "42".Maybe<int>());
        }

        [TestMethod]
        public void ValidGuid()
        {
            Assert.AreEqual(new Guid("{90F7BC40-0C3D-46D2-8674-D6F6475A0FBF}"), "{90F7BC40-0C3D-46D2-8674-D6F6475A0FBF}".Maybe<Guid>());
        }
    }
}
