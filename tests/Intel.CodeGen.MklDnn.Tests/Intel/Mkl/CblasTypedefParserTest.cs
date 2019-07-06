using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Intel.CodeGen.MklDnn.Ipp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intel.CodeGen.MklDnn.Mkl;

namespace Intel.CodeGen.MklDnn.Test.Intel.Mkl
{
    [TestClass]
    public class CblasTypedefParserTest
    {
        CblasTypedefParser m_parser = new CblasTypedefParser();

        readonly Typedef Typedef_CblasOrder = new Typedef("enum", "CBLAS_ORDER", new[] { "CblasRowMajor=101, CblasColMajor=102" });

        [TestMethod]
        public void CblasTypedefParseTest_ParseTypedefsInResource()
        {
            var typedefs = ParseTypedefsInResource("mkl_cblas.h").ToList();

            Assert.AreEqual(Typedef_CblasOrder, typedefs[0]);
            Assert.AreEqual(5, typedefs.Count); // Update when ipp changes, do check
        }


        public IEnumerable<Typedef> ParseTypedefsInResource(string filename)
        {
            var reader = TestHelper.GetResourceReaderWhichEndsWith(filename);
            return m_parser.ParseTypedefs(reader);
        }
    }
}
