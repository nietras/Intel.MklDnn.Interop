using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intel.CodeGen.MklDnn.Mkl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Mkl
{
    [TestClass]
    public class LapackeHelperTest
    {
        const string MethodStringA = "lapack_int LAPACKE_slasrt( char id, lapack_int n, float* d);";
        readonly Method MethodA = new Method("lapack_int", "LAPACKE_slasrt", new Parameter[] { 
            new Parameter("char", "id"), new Parameter("lapack_int", "n"), new Parameter("float*", "d"), });

        const string MethodStringB = "lapack_int LAPACKE_sbdsdc( int matrix_order, char uplo, char compq, lapack_int n, float* d, float* e, float* u, lapack_int ldu, float* vt, lapack_int ldvt, float* q, lapack_int* iq );";
        readonly Method MethodB = new Method("lapack_int", "LAPACKE_sbdsdc", new Parameter[] { 
            new Parameter("int", "matrix_order"), new Parameter("char", "uplo"), new Parameter("char", "compq"), new Parameter("lapack_int", "n"), 
            new Parameter("float*", "d"), new Parameter("float*", "e"), new Parameter("float*", "u"), new Parameter("lapack_int", "ldu"), 
            new Parameter("float*", "vt"), new Parameter("lapack_int", "ldvt"), new Parameter("float*", "q"), new Parameter("lapack_int*", "iq"), });

        [TestMethod]
        public void LapackeHelperTest_ParseMethodA()
        {
            var actual = LapackeHelper.ParseMethod(MethodStringA);
            Assert.AreEqual(MethodA, actual);
        }

        [TestMethod]
        public void LapackeHelperTest_ParseMethodB()
        {
            var actual = LapackeHelper.ParseMethod(MethodStringB);
            Assert.AreEqual(MethodB, actual);
        }

        //[TestMethod]
        //public void LapackeHelperTest_WrapTypedefName()
        //{
        //    Assert.AreEqual("LapackeOrder", LapackeHelper.WrapTypedefName("CBLAS_ORDER"));
        //    Assert.AreEqual("LapackeTranspose", LapackeHelper.WrapTypedefName("CBLAS_TRANSPOSE"));
        //}

        //[TestMethod]
        //public void LapackeHelperTest_WrapEnumValue()
        //{
        //    Assert.AreEqual("RowMajor=101, ColMajor=102", LapackeHelper.WrapEnumValue("LapackeRowMajor=101, LapackeColMajor=102"));
        //}
    }
}
