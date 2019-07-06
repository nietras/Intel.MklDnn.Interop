using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppcoreTypedefParseTest : IppTypedefParseTest
    {
        readonly Typedef Typedef0 = new Typedef("enum", "IppAffinityType",     
                @"ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
                ippAffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
                ippAffinityAllEnabled,      /* KMP_AFFINITY=respect */
                ippAffinityRestore,
                ippTstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
                ippTstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */"
                    .Split(new []{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray()
            );

        [TestMethod]
        public void IppcoreTypedefParseTest_ParseTypedefsInResource()
        {
            var typedefs = ParseTypedefsInResource("ippcore.h").ToList();

            Assert.AreEqual(Typedef0, typedefs[0]);
            Assert.AreEqual(1, typedefs.Count); // Update when ipp changes, do check
        }
    }
}
