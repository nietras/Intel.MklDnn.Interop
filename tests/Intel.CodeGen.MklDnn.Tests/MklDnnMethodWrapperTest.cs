using System;
using Intel.CodeGen.MklDnn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class MklDnnMethodWrapperTest
    {
        MklDnnTypeWrapper m_typeWrapper = new MklDnnTypeWrapper(
              new Typedef("struct", "MklDnn8sc", new string[] { })
            , new Typedef("struct", "MklDnn32sc", new string[] { })
            , new Typedef("struct", "MklDnniSize", new string[] { })
            , new Typedef("struct", "MklDnnLibraryVersion", new string[] { }) // No lines needed here
            , new Typedef("enum", "MklDnnAffinityType", new string[] { }) // No lines needed here
            , new Typedef("enum", "MklDnnStatus", new string[] { }) // No lines needed here
            );
        MklDnnMethodWrapper m_wrapper;

        public MklDnnMethodWrapperTest()
        {
            m_wrapper = new MklDnnMethodWrapper(m_typeWrapper);
        }

        readonly Method MethodA = new Method("MklDnn8u*", "ippiMalloc_8u_C1", new Parameter[] { new Parameter("int", "widthPixels"), new Parameter("int", "heightPixels"), new Parameter("int*", "pStepBytes"), });
        const string MethodStringA =
@"MklDnn8u* Malloc_8u_C1(int widthPixels, int heightPixels, int* pStepBytes)
{    return ippiMalloc_8u_C1(widthPixels, heightPixels, pStepBytes); }";

        readonly Method MethodB = new Method("const MklDnnLibraryVersion*", "ippGetLibVersion", new Parameter[] { });
        const string MethodStringB =
@"NMklDnnLibraryVersion* GetLibVersion()
{    return (NMklDnnLibraryVersion*)(ippGetLibVersion()); }";

        readonly Method MethodC = new Method("MklDnnStatus", "ippiAddC_16u_C3RSfs", new Parameter[] { 
            new Parameter("const MklDnn16u*", "pSrc"), new Parameter("int", "srcStep"),
            new Parameter("const MklDnn16u", "value", new StaticArraySize(new []{ 3 })), 
            new Parameter("MklDnn16u*", "pDst"), new Parameter("int", "dstStep"),
            new Parameter("MklDnniSize", "roiSize"), new Parameter("int", "scaleFactor"),
        });
        const string MethodStringC =
@"NMklDnnStatus AddC_16u_C3RSfs(const MklDnn16u* pSrc, int srcStep, MklDnn16u* value, MklDnn16u* pDst, int dstStep, NMklDnniSize roiSize, int scaleFactor)
{
    MklDnn16u value_[3];
    auto valuePtr = &value_[0];
    for (int i = 0; i < 3; ++i) { valuePtr[i] = value[i]; }
    return static_cast<NMklDnnStatus>(ippiAddC_16u_C3RSfs(pSrc, srcStep, value_, pDst, dstStep, *reinterpret_cast<MklDnniSize*>(&roiSize), scaleFactor));
}";

        readonly Method MethodD = new Method("MklDnn32sc*", "ippiMalloc_32sc_C2", new Parameter[] { new Parameter("int", "widthPixels"), new Parameter("int", "heightPixels"), new Parameter("int*", "pStepBytes"), });
        const string MethodStringD =
@"NMklDnn32sc* Malloc_32sc_C2(int widthPixels, int heightPixels, int* pStepBytes)
{    return reinterpret_cast<NMklDnn32sc*>(ippiMalloc_32sc_C2(widthPixels, heightPixels, pStepBytes)); }";

        readonly Method MethodE = new Method("MklDnnStatus", "ippiAdd_8u_C1RSfs", 
            new Parameter[] { new Parameter("const MklDnn8u*", "pSrc1"), new Parameter("int", "src1Step"), new Parameter("const MklDnn8u*", "pSrc2"), new Parameter("int", "src2Step"), 
                new Parameter("MklDnn8u*", "pDst"), new Parameter("int", "dstStep"), new Parameter("MklDnniSize", "roiSize"), new Parameter("int", "scaleFactor"), });
        const string MethodStringE =
@"NMklDnnStatus Add_8u_C1RSfs(const MklDnn8u* pSrc1, int src1Step, const MklDnn8u* pSrc2, int src2Step, MklDnn8u* pDst, int dstStep, NMklDnniSize roiSize, int scaleFactor)
{    return static_cast<NMklDnnStatus>(ippiAdd_8u_C1RSfs(pSrc1, src1Step, pSrc2, src2Step, pDst, dstStep, *reinterpret_cast<MklDnniSize*>(&roiSize), scaleFactor)); }";

// MKLDNNAPI(MklDnnStatus, ippiBGRToHLS_8u_AP4C4R, (const MklDnn8u*  pSrc[4], int srcStep, MklDnn8u* pDst, int dstStep, MklDnniSize roiSize))
        readonly Method MethodF = new Method("MklDnnStatus", "ippiBGRToHLS_8u_AP4C4R", new Parameter[] { 
            new Parameter("const MklDnn8u*", "pSrc", new StaticArraySize(new []{ 4 })), new Parameter("int", "srcStep"),
            new Parameter("MklDnn8u*", "pDst"), new Parameter("int", "dstStep"),
            new Parameter("MklDnniSize", "roiSize")
        });
        const string MethodStringF =
@"NMklDnnStatus BGRToHLS_8u_AP4C4R(MklDnn8u** pSrc, int srcStep, MklDnn8u* pDst, int dstStep, NMklDnniSize roiSize)
{
    const MklDnn8u* pSrc_[4];
    auto pSrcPtr = &pSrc_[0];
    for (int i = 0; i < 4; ++i) { pSrcPtr[i] = pSrc[i]; }
    return static_cast<NMklDnnStatus>(ippiBGRToHLS_8u_AP4C4R(pSrc_, srcStep, pDst, dstStep, *reinterpret_cast<MklDnniSize*>(&roiSize)));
}";

//MKLDNNAPI (MklDnnStatus, ippiAlphaPremul_8u_AP4R,
//                   ( const MklDnn8u* const pSrc[4], int srcStep,
//                     MklDnn8u* const pDst[4], int dstStep,
//                     MklDnniSize roiSize ))
        readonly Method MethodG = new Method("MklDnnStatus", "ippiAlphaPremul_8u_AP4R", new Parameter[] { 
            new Parameter("const MklDnn8u* const", "pSrc", new StaticArraySize(new []{ 4 })), new Parameter("int", "srcStep"),
            new Parameter("MklDnn8u* const", "pDst", new StaticArraySize(new []{ 4 })), new Parameter("int", "dstStep"),
            new Parameter("MklDnniSize", "roiSize")
        });
        const string MethodStringG =
@"NMklDnnStatus AlphaPremul_8u_AP4R(MklDnn8u** pSrc, int srcStep, MklDnn8u** pDst, int dstStep, NMklDnniSize roiSize)
{
    const MklDnn8u* pSrc_[4];
    auto pSrcPtr = &pSrc_[0];
    for (int i = 0; i < 4; ++i) { pSrcPtr[i] = pSrc[i]; }
    MklDnn8u* pDst_[4];
    auto pDstPtr = &pDst_[0];
    for (int i = 0; i < 4; ++i) { pDstPtr[i] = pDst[i]; }
    return static_cast<NMklDnnStatus>(ippiAlphaPremul_8u_AP4R(pSrc_, srcStep, pDst_, dstStep, *reinterpret_cast<MklDnniSize*>(&roiSize)));
}";


        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodA()
        {
            var actual = m_wrapper.WrapMethod(MethodA);
            Assert.AreEqual(MethodStringA, actual);
        }

        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodB()
        {
            var actual = m_wrapper.WrapMethod(MethodB);
            Assert.AreEqual(MethodStringB, actual);
        }

        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodC()
        {
            var actual = m_wrapper.WrapMethod(MethodC);
            Assert.AreEqual(MethodStringC, actual);
        }

        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodD()
        {
            var actual = m_wrapper.WrapMethod(MethodD);
            Assert.AreEqual(MethodStringD, actual);
        }

        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodE()
        {
            var actual = m_wrapper.WrapMethod(MethodE);
            Assert.AreEqual(MethodStringE, actual);
        }

        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodF()
        {
            var actual = m_wrapper.WrapMethod(MethodF);
            Assert.AreEqual(MethodStringF, actual);
        }

        [TestMethod]
        public void MklDnnMethodWrapperTest_WrapMethodG()
        {
            var actual = m_wrapper.WrapMethod(MethodG);
            Assert.AreEqual(MethodStringG, actual);
        }
    }
}
