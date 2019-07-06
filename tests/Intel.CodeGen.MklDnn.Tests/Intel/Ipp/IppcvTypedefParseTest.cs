using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppcvTypedefParseTest : IppTypedefParseTest
    {
        readonly Typedef Typedef1 = new Typedef("enum", "IppiNorm", new string[] { "ippiNormInf = 0", "ippiNormL1 = 1", "ippiNormL2 = 2", "ippiNormFM = 3" });
        readonly Typedef Typedef9 = new Typedef("struct", "IppiPyramidDownState_8u_C1R", new string[0]);

        [TestMethod]
        public void IppcvTypedefParseTest_ParseTypedefsInResource()
        {
            var typedefs = ParseTypedefsInResource("ippcv.h").ToList();

            Assert.AreEqual(Typedef9, typedefs[9]);
            Assert.AreEqual(40, typedefs.Count); // Update when ipp changes, do check
        }
    }
}
