using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intel.CodeGen.MklDnn.Mkl;

namespace Intel.CodeGen.MklDnn.Test.Intel.Mkl
{
    [TestClass]
    public class CblasMethodParserTest
    {
        CblasMethodParser m_parser = new CblasMethodParser();
        readonly Method Method0 = new Method("double", "cblas_dcabs1", new Parameter[] { new Parameter("const void  *", "z") });
        readonly Method Method24 = new Method("CBLAS_INDEX", "cblas_isamax", new Parameter[] { new Parameter("const MKL_INT", "N"), new Parameter("const float  *", "X"), new Parameter("const MKL_INT", "incX") });

        [TestMethod]
        public void CblasParseTest_ParseMethodsInResource()
        {
            var methods = ParseMethodsInResource("mkl_cblas.h").ToList();

            Assert.AreEqual(Method0, methods[0]);
            Assert.AreEqual(Method24, methods[24]);

            Assert.AreEqual(182, methods.Count); // Update when mkl changes, do check
        }

        public IEnumerable<Method> ParseMethodsInResource(string filename)
        {
            var reader = TestHelper.GetResourceReaderWhichEndsWith(filename);
            return m_parser.ParseMethods(reader);
        }
    }
}
