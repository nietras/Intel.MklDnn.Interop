using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class ParameterTest
    {

        [TestMethod]
        public void ParameterTest_RemoveParameterNameDecoration()
        {
            Assert.AreEqual("value", Parameter.RemoveParameterDecoration("*value"));
            Assert.AreEqual("value", Parameter.RemoveParameterDecoration("value"));
            Assert.AreEqual("value", Parameter.RemoveParameterDecoration("value[3]"));
        }
    }
}
