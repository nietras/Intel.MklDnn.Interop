using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Intel.CodeGen.MklDnn.Ipp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppiMethodParseTest : IppMethodParseTest
    {
        readonly Method Method0 = new Method("const IppLibraryVersion*", "ippiGetLibVersion", new Parameter[] { });
        readonly Method Method1 = new Method("Ipp8u*", "ippiMalloc_8u_C1", new Parameter[] { new Parameter("int", "widthPixels"), new Parameter("int", "heightPixels"), new Parameter("int*", "pStepBytes"), });
        readonly Method Method37 = new Method("IppStatus", "ippiAdd_8u_C1RSfs",
            new Parameter[] { new Parameter("const Ipp8u*", "pSrc1"), new Parameter("int", "src1Step"), new Parameter("const Ipp8u*", "pSrc2"), new Parameter("int", "src2Step"), 
                new Parameter("Ipp8u*", "pDst"), new Parameter("int", "dstStep"), new Parameter("IppiSize", "roiSize"), new Parameter("int", "scaleFactor"), });

        [TestMethod]
        public void IppiParseTest_ParseMethodsInResource()
        {
            var methods = ParseMethodsInResource("ippi.h").ToList();

            Assert.AreEqual(Method0, methods[0]);
            Assert.AreEqual(Method1, methods[1]);
            Assert.AreEqual(Method37, methods[37]);

            Assert.AreEqual(2890, methods.Count); // Update when ipp changes, do check
            // Check a sample of deprecated are not in output
            Assert.IsFalse(methods.Any(m => m.Name.Equals("ippiAdd_8u_AC4RSfs")));
            Assert.IsFalse(methods.Any(m => m.Name.Equals("ippiDiv_16sc_C1RSfs")));
            Assert.IsFalse(methods.Any(m => m.Name.Equals("ippiMulC_16sc_C3IRSfs")));
        }
    }
}
