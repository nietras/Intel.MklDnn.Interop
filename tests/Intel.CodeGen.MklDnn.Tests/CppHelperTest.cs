using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class CppHelperTest
    {
        [TestMethod]
        public void CppHelperTest_WrapTypedefType()
        {
            Assert.AreEqual("enum class", CppHelper.WrapTypedefType("enum"));
            Assert.AreEqual("value struct", CppHelper.WrapTypedefType("struct"));
        }

    }
}
