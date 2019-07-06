using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            var methods = ParseMethodsInResource("mkldnn.h").ToList();

            Assert.AreEqual(106, methods.Count); // Update when header changes, do check

            //Assert.AreEqual(Method0, methods[0]);
            //Assert.AreEqual(Method1, methods[1]);
            //// Check a sample of deprecated are not in output
            //Assert.IsFalse(methods.Any(m => m.Name.Equals("ippStaticInit")));
            //Assert.IsFalse(methods.Any(m => m.Name.Equals("ippStatusToMessageIdI18n")));            
        }
    }
}
