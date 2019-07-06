using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void StringExtensionsTest_KeepAlphaNumeric()
        {
            Assert.AreEqual("1a2B3c-4", "1{)a([];2B!3}c-4".KeepAlphaNumeric());
            Assert.AreEqual("123abc", "123 abc".KeepAlphaNumeric());
        }
    }
}
