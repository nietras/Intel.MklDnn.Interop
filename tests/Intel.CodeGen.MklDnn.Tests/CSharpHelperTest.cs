using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class CSharpHelperTest
    {
        [TestMethod]
        public void CppHelperTest_WrapTypedefType()
        {
            Assert.AreEqual("enum", CSharpHelper.WrapTypedefType("enum"));
            Assert.AreEqual("readonly struct", CSharpHelper.WrapTypedefType("struct"));
        }

    }
}
