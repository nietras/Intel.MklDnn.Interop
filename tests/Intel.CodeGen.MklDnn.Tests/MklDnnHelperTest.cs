using System;
using System.Linq;
using Intel.CodeGen.MklDnn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class MklDnnHelperTest
    {
        readonly Method MethodA = new Method("mkldnn_status_t", "mkldnn_primitive_desc_iterator_next", new Parameter[]{ new Parameter("mkldnn_primitive_desc_iterator_t", "iterator") });
        const string MethodStringA = @"mkldnn_status_t MKLDNN_API mkldnn_primitive_desc_iterator_next(
        mkldnn_primitive_desc_iterator_t iterator)";

        readonly Method MethodB = new Method("MklDnnStatus", "ippiMulPack_32f_C4R", new Parameter[] { 
            new Parameter("const MklDnn32f*", "pSrc1"), new Parameter("int", "src1Step"), 
            new Parameter("const MklDnn32f*", "pSrc2"), new Parameter("int", "src2Step"), 
            new Parameter("MklDnn32f*", "pDst"), new Parameter("int", "dstStep"), 
            new Parameter("MklDnniSize", "roiSize"), });
        const string MethodStringB = @"MKLDNNAPI(MklDnnStatus, ippiMulPack_32f_C4R, (const MklDnn32f* pSrc1, int src1Step, const MklDnn32f* pSrc2, int src2Step,
                                        MklDnn32f* pDst, int dstStep, MklDnniSize roiSize))";

        const string MethodStringC = @"MKLDNNAPI( const MklDnnLibraryVersion*, ippiGetLibVersion, (void) )";
        readonly Method MethodC = new Method("const MklDnnLibraryVersion*", "ippiGetLibVersion", new Parameter[] { });

        const string MethodStringD = @"MKLDNNAPI(MklDnnStatus, ippiHoughLine_Region_8u32f_C1R, (const MklDnn8u* pSrc, int srcStep, MklDnniSize roiSize, MklDnnPointPolar* pLine, MklDnnPointPolar dstRoi[2], int maxLineCount, int* pLineCount, MklDnnPointPolar delta, int threshold, MklDnn8u* pBuffer))";
        readonly Method MethodD = new Method("MklDnnStatus", "ippiHoughLine_Region_8u32f_C1R",
            new Parameter[] { new Parameter("const MklDnn8u*", "pSrc"), new Parameter("int", "srcStep"), new Parameter("MklDnniSize", "roiSize"), new Parameter("MklDnnPointPolar*", "pLine"), 
                              new Parameter("MklDnnPointPolar", "dstRoi", new StaticArraySize(new []{2})), new Parameter("int", "maxLineCount"), new Parameter("int*", "pLineCount"), new Parameter("MklDnnPointPolar", "delta"), new Parameter("int", "threshold"), new Parameter("MklDnn8u*", "pBuffer"), });

        const string MethodStringE = @"MKLDNNAPI(MklDnnStatus,ippiBGRToYCoCg_8u16s_C3P3R,(const MklDnn8u*  pBGR, int bgrStep, MklDnn16s* pYCC [3], int yccStep, MklDnniSize roiSize ))";
        readonly Method MethodE = new Method("MklDnnStatus", "ippiBGRToYCoCg_8u16s_C3P3R",
            new Parameter[] { new Parameter("const MklDnn8u*", "pBGR"), new Parameter("int", "bgrStep"), new Parameter("MklDnn16s*", "pYCC", new StaticArraySize(new[] { 3 })), new Parameter("int", "yccStep"), new Parameter("MklDnniSize", "roiSize"), });

        const string MethodStringF = @"MKLDNNAPI (MklDnnStatus, ippiAlphaComp_16u_AP4R,( const MklDnn16u* const pSrc1[4], int src1Step, const MklDnn16u* const pSrc2[4], int src2Step, MklDnn16u* const pDst[4], int dstStep, MklDnniSize roiSize, MklDnniAlphaType alphaType ))";
        readonly Method MethodF = new Method("MklDnnStatus", "ippiAlphaComp_16u_AP4R",
            new Parameter[] { new Parameter("const MklDnn16u* const", "pSrc1", new StaticArraySize(new[] { 4 })), new Parameter("int", "src1Step"), new Parameter("const MklDnn16u* const", "pSrc2", new StaticArraySize(new[] { 4 })), new Parameter("int", "src2Step"), new Parameter("MklDnn16u* const", "pDst", new StaticArraySize(new[] { 4 })), new Parameter("int", "dstStep"), new Parameter("MklDnniSize", "roiSize"), new Parameter("MklDnniAlphaType", "alphaType") });

        const string MethodStringG = @"MKLDNNAPI ( MklDnnStatus, ippiColorTwist_32f_P3R, ( const MklDnn32f* pSrc[3], int srcStep, MklDnn32f* pDst[3], int dstStep, MklDnniSize roiSize, const MklDnn32f twist[3][4] ))";
        readonly Method MethodG = new Method("MklDnnStatus", "ippiColorTwist_32f_P3R",
            new Parameter[] { new Parameter("const MklDnn32f*", "pSrc", new StaticArraySize(new[] { 3 })), new Parameter("int", "srcStep"), new Parameter("MklDnn32f*", "pDst", new StaticArraySize(new[] { 3 })), new Parameter("int", "dstStep"), new Parameter("MklDnniSize", "roiSize"), new Parameter("const MklDnn32f", "twist", new StaticArraySize(new[] { 3, 4 })), });

        const string TypedefString0 = @"typedef enum {
    ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
    ippAffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
    ippAffinityAllEnabled,      /* KMP_AFFINITY=respect */
    ippAffinityRestore,
    ippTstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
    ippTstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */
} MklDnnAffinityType;";
        readonly Typedef Typedef0 = new Typedef("enum", "MklDnnAffinityType",
                @"ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
                ippAffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
                ippAffinityAllEnabled,      /* KMP_AFFINITY=respect */
                ippAffinityRestore,
                ippTstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
                ippTstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */"
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray()
            );

        const string TypedefString1 = @"typedef enum {
    ippiFilterBilateralGauss = 100,
    ippiFilterBilateralGaussFast = 101
} MklDnniFilterBilateralType;";
        readonly Typedef Typedef1 = new Typedef("enum", "MklDnniFilterBilateralType",
                new string []{ "ippiFilterBilateralGauss = 100,",  "ippiFilterBilateralGaussFast = 101" }
            );

        const string TypedefString2 = @"typedef struct {
    MklDnn32u borderLeft;
    MklDnn32u borderTop;
    MklDnn32u borderRight;
    MklDnn32u borderBottom;
} MklDnniBorderSize;";
        readonly Typedef Typedef2 = new Typedef("struct", "MklDnniBorderSize",
                new string[] { "MklDnn32u borderLeft;", "MklDnn32u borderTop;", "MklDnn32u borderRight;", "MklDnn32u borderBottom;" }
            );

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodA()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringA);

            Assert.AreEqual(MethodA, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodB()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringB);

            Assert.AreEqual(MethodB, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodC()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringC);

            Assert.AreEqual(MethodC, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodD()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringD);

            Assert.AreEqual(MethodD, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodE()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringE);

            Assert.AreEqual(MethodE, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodF()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringF);

            Assert.AreEqual(MethodF, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseMethodG()
        {
            var actual = MklDnnHelper.ParseMethod(MethodStringG);

            Assert.AreEqual(MethodG, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseParameter()
        {
            Assert.AreEqual(new Parameter("const MklDnn16u* const", "pSrc1", new StaticArraySize(new[] { 4 })), MklDnnHelper.ParseParameter("const MklDnn16u* const pSrc1[4]"));
            Assert.AreEqual(new Parameter("const double", "coeffs", new StaticArraySize(new[] { 2, 3 })), MklDnnHelper.ParseParameter("const double coeffs[2][3]"));
            Assert.AreEqual(new Parameter("const MklDnn8u **", "p"), MklDnnHelper.ParseParameter("const MklDnn8u *p[]"));
            Assert.AreEqual(new Parameter("MklDnn16s*", "pYCC", new StaticArraySize(new[] { 3 })), MklDnnHelper.ParseParameter(" MklDnn16s* pYCC [3]"));
            Assert.AreEqual(new Parameter("unsigned int*", "pUMask"), MklDnnHelper.ParseParameter(" unsigned int* pUMask "));
            Assert.AreEqual(new Parameter("MklDnniSize", "roiSize"), MklDnnHelper.ParseParameter("MklDnniSize roiSize "));
            Assert.AreEqual(new Parameter("MklDnn32fc *", "pDst"), MklDnnHelper.ParseParameter("MklDnn32fc *pDst"));
            Assert.AreEqual(new Parameter("const MklDnn32f*", "pSrcMagn"), MklDnnHelper.ParseParameter("const MklDnn32f* pSrcMagn"));
            Assert.AreEqual(new Parameter("int", "srcStep"), MklDnnHelper.ParseParameter("int srcStep"));
            Assert.AreEqual(new Parameter("int", "value", new StaticArraySize(new[] { 3 })), MklDnnHelper.ParseParameter("int value[3]"));
        }

        [TestMethod]
        public void MklDnnHelperTest_WrapMethodName()
        {
            Assert.AreEqual("GetLibVersion", MklDnnHelper.WrapMethodName("ippGetLibVersion"));
            Assert.AreEqual("GetLibVersion", MklDnnHelper.WrapMethodName("ippiGetLibVersion"));
            Assert.AreEqual("MulPack_32f_C4R", MklDnnHelper.WrapMethodName("ippiMulPack_32f_C4R"));
            Assert.AreEqual("Test", MklDnnHelper.WrapMethodName("ippsTest"));
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseTypedef0()
        {
            var actual = MklDnnHelper.ParseTypedef(TypedefString0);

            Assert.AreEqual(Typedef0, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseTypedef1()
        {
            var actual = MklDnnHelper.ParseTypedef(TypedefString1);

            Assert.AreEqual(Typedef1, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_ParseTypedef2()
        {
            var actual = MklDnnHelper.ParseTypedef(TypedefString2);

            Assert.AreEqual(Typedef2, actual);
        }

        [TestMethod]
        public void MklDnnHelperTest_WrapTypedefName()
        {
            Assert.AreEqual("NMklDnniBorderSize", MklDnnHelper.WrapTypedefName("MklDnniBorderSize"));
            Assert.AreEqual("NMklDnniPoint_32f", MklDnnHelper.WrapTypedefName("MklDnniPoint_32f"));
            Assert.AreEqual("NMklDnniFilterBilateralType", MklDnnHelper.WrapTypedefName("MklDnniFilterBilateralType"));
            Assert.AreEqual("NMklDnnAffinityType", MklDnnHelper.WrapTypedefName("MklDnnAffinityType"));
            Assert.AreEqual("NMklDnnsTest", MklDnnHelper.WrapTypedefName("MklDnnsTest"));
            Assert.AreEqual("NMklDnn8sc", MklDnnHelper.WrapTypedefName("MklDnn8sc"));
            Assert.AreEqual("NMklDnn64sc", MklDnnHelper.WrapTypedefName("MklDnn64sc"));
            Assert.AreEqual("NMklDnn64fc", MklDnnHelper.WrapTypedefName("MklDnn64fc"));
        }

        [TestMethod]
        public void MklDnnHelperTest_WrapEnumValue()
        {
            Assert.AreEqual("AffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */", MklDnnHelper.WrapEnumValue("ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */"));
            Assert.AreEqual("AffinityRestore,", MklDnnHelper.WrapEnumValue("ippAffinityRestore,"));
        }
    }
}
