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
    public class CblasHelperTest
    {
        const string TypedefString_CblasOrder = "typedef enum {CblasRowMajor=101, CblasColMajor=102} CBLAS_ORDER";
        readonly Typedef Typedef_CblasOrder = new Typedef("enum", "CBLAS_ORDER", new []{ "CblasRowMajor=101, CblasColMajor=102" } );

        const string MethodStringA = "double cblas_dcabs1(const void  *z);";
        readonly Method MethodA = new Method("double", "cblas_dcabs1", new Parameter[] { new Parameter("const void  *", "z") });

        const string MethodStringB = "CBLAS_INDEX cblas_isamax(const MKL_INT N, const float  *X, const MKL_INT incX);";
        readonly Method MethodB = new Method("CBLAS_INDEX", "cblas_isamax", new Parameter[] { new Parameter("const MKL_INT", "N"), new Parameter("const float  *", "X"), new Parameter("const MKL_INT", "incX") });

        [TestMethod]
        public void CblasHelperTest_ParseTypedef_CblasOrder()
        {
            var actual = CblasHelper.ParseTypedef(TypedefString_CblasOrder);
            Assert.AreEqual(Typedef_CblasOrder, actual);
        }

        [TestMethod]
        public void CblasHelperTest_ParseMethodA()
        {
            var actual = CblasHelper.ParseMethod(MethodStringA);
            Assert.AreEqual(MethodA, actual);
        }

        [TestMethod]
        public void CblasHelperTest_ParseMethodB()
        {
            var actual = CblasHelper.ParseMethod(MethodStringB);
            Assert.AreEqual(MethodB, actual);
        }


        [TestMethod]
        public void CblasHelperTest_WrapTypedefName()
        {
            Assert.AreEqual("CblasOrder", CblasHelper.WrapTypedefName("CBLAS_ORDER"));
            Assert.AreEqual("CblasTranspose", CblasHelper.WrapTypedefName("CBLAS_TRANSPOSE"));
        }

        [TestMethod]
        public void CblasHelperTest_WrapEnumValue()
        {
            Assert.AreEqual("RowMajor=101, ColMajor=102", CblasHelper.WrapEnumValue("CblasRowMajor=101, CblasColMajor=102"));
        }
    }
}
