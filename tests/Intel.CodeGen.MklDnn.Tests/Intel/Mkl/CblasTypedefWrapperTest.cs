using System;
using System.Linq;
using Intel.CodeGen.MklDnn.Mkl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Mkl
{
    [TestClass]
    public class CblasTypedefWrapperTest
    {
        // No lines necessary for this test
        CblasTypedefWrapper m_wrapper = new CblasTypedefWrapper();

        readonly Typedef Typedef_CblasOrder = new Typedef("enum", "CBLAS_ORDER", new[] { "CblasRowMajor=101, CblasColMajor=102" });
        const string TypedefString_CblasOrder =
@"public enum class CblasOrder
{
    RowMajor=101, ColMajor=102
};";

        [TestMethod]
        public void CblasTypedefWrapperTest_WrapTypedef_CBlasOrder()
        {
            var actual = m_wrapper.WrapTypedef(Typedef_CblasOrder);
            Assert.AreEqual(TypedefString_CblasOrder, actual);
        }
    }
}
