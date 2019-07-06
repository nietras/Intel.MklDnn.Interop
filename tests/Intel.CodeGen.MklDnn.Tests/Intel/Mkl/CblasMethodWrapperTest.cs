using System;
using Intel.CodeGen.MklDnn.Mkl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Cblas
{
    [TestClass]
    public class CblasMethodWrapperTest
    {
        CblasTypeWrapper m_typeWrapper = new CblasTypeWrapper(
              new Typedef("enum", "CBLAS_ORDER", new []{ "CblasRowMajor=101, CblasColMajor=102" } )
            , new Typedef("enum", "CBLAS_TRANSPOSE", new [] { "CblasNoTrans=111, CblasTrans=112, CblasConjTrans=113" })
            , new Typedef("enum", "CBLAS_UPLO", new [] { "CblasUpper=121, CblasLower=122" })
            , new Typedef("enum", "CBLAS_DIAG", new [] { "CblasNonUnit=131, CblasUnit=132" })
            , new Typedef("enum", "CBLAS_SIDE", new [] { "CblasLeft=141, CblasRight=142" })
            );

        CblasMethodWrapper m_wrapper;

        public CblasMethodWrapperTest()
        {
            m_wrapper = new CblasMethodWrapper(m_typeWrapper);
        }

        readonly Method MethodA = new Method("double", "cblas_dcabs1", new Parameter[] { new Parameter("const void  *", "z") });
        const string MethodStringA =
@"double dcabs1(MklComplex16  * z)
{    return cblas_dcabs1(z); }";

        readonly Method MethodB = new Method("CBLAS_INDEX", "cblas_isamax", new Parameter[] { new Parameter("const MKL_INT", "N"), new Parameter("const float  *", "X"), new Parameter("const MKL_INT", "incX") });
        const string MethodStringB =
@"CBLAS_INDEX isamax(const MKL_INT N, const float  * X, const MKL_INT incX)
{    return cblas_isamax(N, X, incX); }";

        readonly Method MethodC = new Method("void", "cblas_sgemv", 
            new Parameter[] { new Parameter("const  CBLAS_ORDER", "order"), new Parameter("const  CBLAS_TRANSPOSE", "TransA"), new Parameter("const MKL_INT", "M"), new Parameter("const MKL_INT", "N"), new Parameter("const float", "alpha"),
                              new Parameter("const float *", "A"), new Parameter("const MKL_INT", "lda"), new Parameter("const float *", "X"), new Parameter("const MKL_INT", "incX"), new Parameter("const float", "beta"),
                              new Parameter("float *", "Y"), new Parameter("const MKL_INT", "incY") });
        const string MethodStringC =
@"void sgemv(CblasOrder order, CblasTranspose TransA, const MKL_INT M, const MKL_INT N, const float alpha, const float * A, const MKL_INT lda, const float * X, const MKL_INT incX, const float beta, float * Y, const MKL_INT incY)
{    cblas_sgemv(static_cast<CBLAS_ORDER>(order), static_cast<CBLAS_TRANSPOSE>(TransA), M, N, alpha, A, lda, X, incX, beta, Y, incY); }";


        [TestMethod]
        public void CblasMethodWrapperTest_WrapMethodA()
        {
            var actual = m_wrapper.WrapMethod(MethodA);
            Assert.AreEqual(MethodStringA, actual);
        }

        [TestMethod]
        public void CblasMethodWrapperTest_WrapMethodB()
        {
            var actual = m_wrapper.WrapMethod(MethodB);
            Assert.AreEqual(MethodStringB, actual);
        }

        [TestMethod]
        public void CblasMethodWrapperTest_WrapMethodC()
        {
            var actual = m_wrapper.WrapMethod(MethodC);
            Assert.AreEqual(MethodStringC, actual);
        }
    }
}
