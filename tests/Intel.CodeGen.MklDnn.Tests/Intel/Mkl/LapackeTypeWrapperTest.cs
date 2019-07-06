using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intel.CodeGen.MklDnn.Mkl;

namespace Intel.CodeGen.MklDnn.Test.Intel.Mkl
{
    [TestClass]
    public class LapackeTypeWrapperTest
    {
        LapackeTypeWrapper m_wrapper = new LapackeTypeWrapper();

        [TestMethod]
        public void LapackeTypeWrapperTest_ShouldWrapType()
        {
            Assert.IsFalse(m_wrapper.ShouldWrapType("MKL_INT"));
            //Assert.IsTrue(m_wrapper.ShouldWrapType("CBLAS_ORDER"));
            //Assert.IsTrue(m_wrapper.ShouldWrapType("CBLAS_TRANSPOSE"));
            //Assert.IsTrue(m_wrapper.ShouldWrapType("CBLAS_UPLO"));
        }

        [TestMethod]
        public void LapackeTypeWrapperTest_WrapType()
        {
            Assert.AreEqual("MklComplex8*", m_wrapper.WrapType("lapack_complex_float*"));
            Assert.AreEqual("MklComplex16*", m_wrapper.WrapType("lapack_complex_double*"));
            Assert.AreEqual("lapack_int", m_wrapper.WrapType("lapack_int"));
            Assert.AreEqual("MKL_INT", m_wrapper.WrapType("MKL_INT"));
            Assert.AreEqual("char", m_wrapper.WrapType("char"));
            Assert.AreEqual("const float  *", m_wrapper.WrapType("const float  *"));
        }

        [TestMethod]
        public void LapackeTypeWrapperTest_CastTypeToMgd()
        {
            Assert.AreEqual("p", m_wrapper.CastTypeToMgd("const float  *", "p"));
            //Assert.AreEqual("static_cast<LapackeOrder>(p)", m_wrapper.CastTypeToMgd("CBLAS_ORDER", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToMgd("CBLAS_INDEX", "p"));
        }

        [TestMethod]
        public void LapackeTypeWrapperTest_CastTypeToNtv()
        {
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("int", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("MKL_INT", "p"));
            Assert.AreEqual("reinterpret_cast<lapack_complex_float*>(p)", m_wrapper.CastTypeToNtv("MklComplex8*", "p"));
            Assert.AreEqual("reinterpret_cast<lapack_complex_double*>(p)", m_wrapper.CastTypeToNtv("MklComplex16*", "p"));
            Assert.AreEqual("reinterpret_cast<lapack_complex_double*>(p)", m_wrapper.CastTypeToNtv("const MklComplex16*", "p"));
        }
    }
}
