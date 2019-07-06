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
    public class LapackeMethodParserTest
    {
        LapackeMethodParser m_parser = new LapackeMethodParser();
        readonly Method Method0 = new Method("lapack_int", "LAPACKE_slasrt", new Parameter[] { 
            new Parameter("char", "id"), new Parameter("lapack_int", "n"), new Parameter("float*", "d"), });

        readonly Method Method6 = new Method("lapack_int", "LAPACKE_sbdsdc", new Parameter[] { 
            new Parameter("int", "matrix_order"), new Parameter("char", "uplo"), new Parameter("char", "compq"), new Parameter("lapack_int", "n"), 
            new Parameter("float*", "d"), new Parameter("float*", "e"), new Parameter("float*", "u"), new Parameter("lapack_int", "ldu"), 
            new Parameter("float*", "vt"), new Parameter("lapack_int", "ldvt"), new Parameter("float*", "q"), new Parameter("lapack_int*", "iq"), });

        [TestMethod]
        public void LapackeParseTest_ParseMethodsInResource()
        {
            var methods = ParseMethodsInResource("mkl_lapacke.h").ToList();

            Assert.AreEqual(Method0, methods[0]);
            Assert.AreEqual(Method6, methods[6]);

            Assert.AreEqual(936, methods.Count); // Update when mkl changes, do check
        }

        public IEnumerable<Method> ParseMethodsInResource(string filename)
        {
            var reader = TestHelper.GetResourceReaderWhichEndsWith(filename);
            return m_parser.ParseMethods(reader);
        }
    }
}
