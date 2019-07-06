using System;
using Intel.CodeGen.MklDnn.Mkl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Lapacke
{
    [TestClass]
    public class LapackeMethodWrapperTest
    {
        LapackeTypeWrapper m_typeWrapper = new LapackeTypeWrapper();

        LapackeMethodWrapper m_wrapper;

        public LapackeMethodWrapperTest()
        {
            m_wrapper = new LapackeMethodWrapper(m_typeWrapper);
        }

        readonly Method MethodA = new Method("lapack_int", "LAPACKE_slasrt", new Parameter[] { 
            new Parameter("char", "id"), new Parameter("lapack_int", "n"), new Parameter("float*", "d"), });
        const string MethodStringA =
@"lapack_int slasrt(char id, lapack_int n, float* d)
{    return LAPACKE_slasrt(id, n, d); }";

        readonly Method MethodB = new Method("lapack_int", "LAPACKE_sbdsdc", new Parameter[] { 
            new Parameter("int", "matrix_order"), new Parameter("char", "uplo"), new Parameter("char", "compq"), new Parameter("lapack_int", "n"), 
            new Parameter("float*", "d"), new Parameter("float*", "e"), new Parameter("float*", "u"), new Parameter("lapack_int", "ldu"), 
            new Parameter("float*", "vt"), new Parameter("lapack_int", "ldvt"), new Parameter("float*", "q"), new Parameter("lapack_int*", "iq"), });
        const string MethodStringB =
@"lapack_int sbdsdc(int matrix_order, char uplo, char compq, lapack_int n, float* d, float* e, float* u, lapack_int ldu, float* vt, lapack_int ldvt, float* q, lapack_int* iq)
{    return LAPACKE_sbdsdc(matrix_order, uplo, compq, n, d, e, u, ldu, vt, ldvt, q, iq); }";

        readonly Method MethodC = new Method("lapack_int", "LAPACKE_cgbcon", new Parameter[] { 
            new Parameter("int", "matrix_order"), new Parameter("char", "norm"), new Parameter("lapack_int", "n"), new Parameter("lapack_int", "kl"), 
            new Parameter("lapack_int", "ku"), new Parameter("const lapack_complex_float*", "ab"), new Parameter("lapack_int", "ldab"), new Parameter("const lapack_int*", "ipiv"), 
            new Parameter("float", "anorm"), new Parameter("float*", "rcond") });
        const string MethodStringC =
@"lapack_int cgbcon(int matrix_order, char norm, lapack_int n, lapack_int kl, lapack_int ku, MklComplex8* ab, lapack_int ldab, const lapack_int* ipiv, float anorm, float* rcond)
{    return LAPACKE_cgbcon(matrix_order, norm, n, kl, ku, reinterpret_cast<lapack_complex_float*>(ab), ldab, ipiv, anorm, rcond); }";

        [TestMethod]
        public void LapackeMethodWrapperTest_WrapMethodA()
        {
            var actual = m_wrapper.WrapMethod(MethodA);
            Assert.AreEqual(MethodStringA, actual);
        }

        [TestMethod]
        public void LapackeMethodWrapperTest_WrapMethodB()
        {
            var actual = m_wrapper.WrapMethod(MethodB);
            Assert.AreEqual(MethodStringB, actual);
        }

        [TestMethod]
        public void LapackeMethodWrapperTest_WrapMethodC()
        {
            var actual = m_wrapper.WrapMethod(MethodC);
            Assert.AreEqual(MethodStringC, actual);
        }
    }
}
