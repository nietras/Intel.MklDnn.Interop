using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intel.CodeGen.MklDnn.Mkl;

namespace Intel.CodeGen.MklDnn.Test.Intel.Mkl
{
    [TestClass]
    public class CblasTypeWrapperTest
    {
        CblasTypeWrapper m_wrapper = new CblasTypeWrapper(
              new Typedef("enum", "CBLAS_ORDER", new[] { "CblasRowMajor=101, CblasColMajor=102" })
            , new Typedef("enum", "CBLAS_TRANSPOSE", new[] { "CblasNoTrans=111, CblasTrans=112, CblasConjTrans=113" })
            , new Typedef("enum", "CBLAS_UPLO", new[] { "CblasUpper=121, CblasLower=122" })
            );

        [TestMethod]
        public void CblasTypeWrapperTest_ShouldWrapType()
        {
            Assert.IsFalse(m_wrapper.ShouldWrapType("MKL_INT"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("CBLAS_ORDER"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("CBLAS_TRANSPOSE"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("CBLAS_UPLO"));
        }

        [TestMethod]
        public void CblasTypeWrapperTest_WrapType()
        {
            Assert.AreEqual("MklComplex16  *", m_wrapper.WrapType("const void  *", "dcabs1"));
            Assert.AreEqual("MklComplex8  *", m_wrapper.WrapType("const void  *", "scabs1"));
            Assert.AreEqual("MklComplex16 *", m_wrapper.WrapType("const void *", "cblas_zdotu_sub"));
            Assert.AreEqual("MklComplex8 *", m_wrapper.WrapType("const void *", "cblas_cdotu_sub"));
            Assert.AreEqual("MklComplex16 *", m_wrapper.WrapType("void *", "cblas_zdotu_sub"));
            Assert.AreEqual("MklComplex8 *", m_wrapper.WrapType("void *", "cblas_cdotu_sub"));
            Assert.AreEqual("CblasOrder", m_wrapper.WrapType("CBLAS_ORDER"));
            Assert.AreEqual("CblasOrder", m_wrapper.WrapType(" CBLAS_ORDER"));
            Assert.AreEqual("CblasTranspose", m_wrapper.WrapType("CBLAS_TRANSPOSE"));
            Assert.AreEqual("CblasUplo", m_wrapper.WrapType("CBLAS_UPLO"));
            Assert.AreEqual("MKL_INT", m_wrapper.WrapType("MKL_INT"));
            Assert.AreEqual("CBLAS_INDEX", m_wrapper.WrapType("CBLAS_INDEX"));
            Assert.AreEqual("const float  *", m_wrapper.WrapType("const float  *"));
        }

        [TestMethod]
        public void CblasTypeWrapperTest_CastTypeToMgd()
        {
            Assert.AreEqual("p", m_wrapper.CastTypeToMgd("const float  *", "p"));
            Assert.AreEqual("static_cast<CblasOrder>(p)", m_wrapper.CastTypeToMgd("CBLAS_ORDER", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToMgd("CBLAS_INDEX", "p"));
        }

        [TestMethod]
        public void CblasTypeWrapperTest_CastTypeToNtv()
        {
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("int", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("MKL_INT", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("CBLAS_INDEX", "p"));
            Assert.AreEqual("static_cast<CBLAS_ORDER>(p)", m_wrapper.CastTypeToNtv("CblasOrder", "p"));
        }
    }
}
