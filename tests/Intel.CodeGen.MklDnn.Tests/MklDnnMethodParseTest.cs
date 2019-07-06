using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class MklDnnMethodParseTest : MklDnnMethodParseBaseTest
    {
        readonly Method Method0 = new Method("const MklDnnLibraryVersion*", "ippGetLibVersion", new Parameter[] { });
        readonly Method Method1 = new Method("const char*", "ippGetStatusString", new Parameter[] { new Parameter("MklDnnStatus", "StsCode") });

        [TestMethod]
        public void MklDnncoreMethodParseTest_ParseMethodsInResource()
        {
            var methods = ParseMethodsInResource("ippcore.h").ToList();

            Assert.AreEqual(Method0, methods[0]);
            Assert.AreEqual(Method1, methods[1]);
            Assert.AreEqual(16, methods.Count); // Update when ipp changes, do check
            // Check a sample of deprecated are not in output
            Assert.IsFalse(methods.Any(m => m.Name.Equals("ippStaticInit")));
            Assert.IsFalse(methods.Any(m => m.Name.Equals("ippStatusToMessageIdI18n")));            
        }
    }
}
