using System;
using Intel.CodeGen.MklDnn.Ipp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppMethodWrapperTest
    {
        IppTypeWrapper m_typeWrapper = new IppTypeWrapper(
              new Typedef("struct", "Ipp8sc", new string[] { })
            , new Typedef("struct", "Ipp32sc", new string[] { })
            , new Typedef("struct", "IppiSize", new string[] { })
            , new Typedef("struct", "IppLibraryVersion", new string[] { }) // No lines needed here
            , new Typedef("enum", "IppAffinityType", new string[] { }) // No lines needed here
            , new Typedef("enum", "IppStatus", new string[] { }) // No lines needed here
            );
        IppMethodWrapper m_wrapper;

        public IppMethodWrapperTest()
        {
            m_wrapper = new IppMethodWrapper(m_typeWrapper);
        }

        readonly Method MethodA = new Method("Ipp8u*", "ippiMalloc_8u_C1", new Parameter[] { new Parameter("int", "widthPixels"), new Parameter("int", "heightPixels"), new Parameter("int*", "pStepBytes"), });
        const string MethodStringA =
@"Ipp8u* Malloc_8u_C1(int widthPixels, int heightPixels, int* pStepBytes)
{    return ippiMalloc_8u_C1(widthPixels, heightPixels, pStepBytes); }";

        readonly Method MethodB = new Method("const IppLibraryVersion*", "ippGetLibVersion", new Parameter[] { });
        const string MethodStringB =
@"NIppLibraryVersion* GetLibVersion()
{    return (NIppLibraryVersion*)(ippGetLibVersion()); }";

        readonly Method MethodC = new Method("IppStatus", "ippiAddC_16u_C3RSfs", new Parameter[] { 
            new Parameter("const Ipp16u*", "pSrc"), new Parameter("int", "srcStep"),
            new Parameter("const Ipp16u", "value", new StaticArraySize(new []{ 3 })), 
            new Parameter("Ipp16u*", "pDst"), new Parameter("int", "dstStep"),
            new Parameter("IppiSize", "roiSize"), new Parameter("int", "scaleFactor"),
        });
        const string MethodStringC =
@"NIppStatus AddC_16u_C3RSfs(const Ipp16u* pSrc, int srcStep, Ipp16u* value, Ipp16u* pDst, int dstStep, NIppiSize roiSize, int scaleFactor)
{
    Ipp16u value_[3];
    auto valuePtr = &value_[0];
    for (int i = 0; i < 3; ++i) { valuePtr[i] = value[i]; }
    return static_cast<NIppStatus>(ippiAddC_16u_C3RSfs(pSrc, srcStep, value_, pDst, dstStep, *reinterpret_cast<IppiSize*>(&roiSize), scaleFactor));
}";

        readonly Method MethodD = new Method("Ipp32sc*", "ippiMalloc_32sc_C2", new Parameter[] { new Parameter("int", "widthPixels"), new Parameter("int", "heightPixels"), new Parameter("int*", "pStepBytes"), });
        const string MethodStringD =
@"NIpp32sc* Malloc_32sc_C2(int widthPixels, int heightPixels, int* pStepBytes)
{    return reinterpret_cast<NIpp32sc*>(ippiMalloc_32sc_C2(widthPixels, heightPixels, pStepBytes)); }";

        readonly Method MethodE = new Method("IppStatus", "ippiAdd_8u_C1RSfs", 
            new Parameter[] { new Parameter("const Ipp8u*", "pSrc1"), new Parameter("int", "src1Step"), new Parameter("const Ipp8u*", "pSrc2"), new Parameter("int", "src2Step"), 
                new Parameter("Ipp8u*", "pDst"), new Parameter("int", "dstStep"), new Parameter("IppiSize", "roiSize"), new Parameter("int", "scaleFactor"), });
        const string MethodStringE =
@"NIppStatus Add_8u_C1RSfs(const Ipp8u* pSrc1, int src1Step, const Ipp8u* pSrc2, int src2Step, Ipp8u* pDst, int dstStep, NIppiSize roiSize, int scaleFactor)
{    return static_cast<NIppStatus>(ippiAdd_8u_C1RSfs(pSrc1, src1Step, pSrc2, src2Step, pDst, dstStep, *reinterpret_cast<IppiSize*>(&roiSize), scaleFactor)); }";

// IPPAPI(IppStatus, ippiBGRToHLS_8u_AP4C4R, (const Ipp8u*  pSrc[4], int srcStep, Ipp8u* pDst, int dstStep, IppiSize roiSize))
        readonly Method MethodF = new Method("IppStatus", "ippiBGRToHLS_8u_AP4C4R", new Parameter[] { 
            new Parameter("const Ipp8u*", "pSrc", new StaticArraySize(new []{ 4 })), new Parameter("int", "srcStep"),
            new Parameter("Ipp8u*", "pDst"), new Parameter("int", "dstStep"),
            new Parameter("IppiSize", "roiSize")
        });
        const string MethodStringF =
@"NIppStatus BGRToHLS_8u_AP4C4R(Ipp8u** pSrc, int srcStep, Ipp8u* pDst, int dstStep, NIppiSize roiSize)
{
    const Ipp8u* pSrc_[4];
    auto pSrcPtr = &pSrc_[0];
    for (int i = 0; i < 4; ++i) { pSrcPtr[i] = pSrc[i]; }
    return static_cast<NIppStatus>(ippiBGRToHLS_8u_AP4C4R(pSrc_, srcStep, pDst, dstStep, *reinterpret_cast<IppiSize*>(&roiSize)));
}";

//IPPAPI (IppStatus, ippiAlphaPremul_8u_AP4R,
//                   ( const Ipp8u* const pSrc[4], int srcStep,
//                     Ipp8u* const pDst[4], int dstStep,
//                     IppiSize roiSize ))
        readonly Method MethodG = new Method("IppStatus", "ippiAlphaPremul_8u_AP4R", new Parameter[] { 
            new Parameter("const Ipp8u* const", "pSrc", new StaticArraySize(new []{ 4 })), new Parameter("int", "srcStep"),
            new Parameter("Ipp8u* const", "pDst", new StaticArraySize(new []{ 4 })), new Parameter("int", "dstStep"),
            new Parameter("IppiSize", "roiSize")
        });
        const string MethodStringG =
@"NIppStatus AlphaPremul_8u_AP4R(Ipp8u** pSrc, int srcStep, Ipp8u** pDst, int dstStep, NIppiSize roiSize)
{
    const Ipp8u* pSrc_[4];
    auto pSrcPtr = &pSrc_[0];
    for (int i = 0; i < 4; ++i) { pSrcPtr[i] = pSrc[i]; }
    Ipp8u* pDst_[4];
    auto pDstPtr = &pDst_[0];
    for (int i = 0; i < 4; ++i) { pDstPtr[i] = pDst[i]; }
    return static_cast<NIppStatus>(ippiAlphaPremul_8u_AP4R(pSrc_, srcStep, pDst_, dstStep, *reinterpret_cast<IppiSize*>(&roiSize)));
}";


        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodA()
        {
            var actual = m_wrapper.WrapMethod(MethodA);
            Assert.AreEqual(MethodStringA, actual);
        }

        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodB()
        {
            var actual = m_wrapper.WrapMethod(MethodB);
            Assert.AreEqual(MethodStringB, actual);
        }

        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodC()
        {
            var actual = m_wrapper.WrapMethod(MethodC);
            Assert.AreEqual(MethodStringC, actual);
        }

        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodD()
        {
            var actual = m_wrapper.WrapMethod(MethodD);
            Assert.AreEqual(MethodStringD, actual);
        }

        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodE()
        {
            var actual = m_wrapper.WrapMethod(MethodE);
            Assert.AreEqual(MethodStringE, actual);
        }

        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodF()
        {
            var actual = m_wrapper.WrapMethod(MethodF);
            Assert.AreEqual(MethodStringF, actual);
        }

        [TestMethod]
        public void IppMethodWrapperTest_WrapMethodG()
        {
            var actual = m_wrapper.WrapMethod(MethodG);
            Assert.AreEqual(MethodStringG, actual);
        }
    }
}
