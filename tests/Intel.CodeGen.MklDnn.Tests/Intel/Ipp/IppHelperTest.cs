using System;
using System.Linq;
using Intel.CodeGen.MklDnn.Ipp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppHelperTest
    {
        readonly Method MethodA = new Method("Ipp8u*", "ippiMalloc_8u_C1", new Parameter[]{ new Parameter("int", "widthPixels"), new Parameter("int", "heightPixels"), new Parameter("int*", "pStepBytes"), });
        const string MethodStringA = "IPPAPI( Ipp8u*,   ippiMalloc_8u_C1,    ( int widthPixels, int heightPixels, int* pStepBytes ) )";

        readonly Method MethodB = new Method("IppStatus", "ippiMulPack_32f_C4R", new Parameter[] { 
            new Parameter("const Ipp32f*", "pSrc1"), new Parameter("int", "src1Step"), 
            new Parameter("const Ipp32f*", "pSrc2"), new Parameter("int", "src2Step"), 
            new Parameter("Ipp32f*", "pDst"), new Parameter("int", "dstStep"), 
            new Parameter("IppiSize", "roiSize"), });
        const string MethodStringB = @"IPPAPI(IppStatus, ippiMulPack_32f_C4R, (const Ipp32f* pSrc1, int src1Step, const Ipp32f* pSrc2, int src2Step,
                                        Ipp32f* pDst, int dstStep, IppiSize roiSize))";

        const string MethodStringC = @"IPPAPI( const IppLibraryVersion*, ippiGetLibVersion, (void) )";
        readonly Method MethodC = new Method("const IppLibraryVersion*", "ippiGetLibVersion", new Parameter[] { });

        const string MethodStringD = @"IPPAPI(IppStatus, ippiHoughLine_Region_8u32f_C1R, (const Ipp8u* pSrc, int srcStep, IppiSize roiSize, IppPointPolar* pLine, IppPointPolar dstRoi[2], int maxLineCount, int* pLineCount, IppPointPolar delta, int threshold, Ipp8u* pBuffer))";
        readonly Method MethodD = new Method("IppStatus", "ippiHoughLine_Region_8u32f_C1R",
            new Parameter[] { new Parameter("const Ipp8u*", "pSrc"), new Parameter("int", "srcStep"), new Parameter("IppiSize", "roiSize"), new Parameter("IppPointPolar*", "pLine"), 
                              new Parameter("IppPointPolar", "dstRoi", new StaticArraySize(new []{2})), new Parameter("int", "maxLineCount"), new Parameter("int*", "pLineCount"), new Parameter("IppPointPolar", "delta"), new Parameter("int", "threshold"), new Parameter("Ipp8u*", "pBuffer"), });

        const string MethodStringE = @"IPPAPI(IppStatus,ippiBGRToYCoCg_8u16s_C3P3R,(const Ipp8u*  pBGR, int bgrStep, Ipp16s* pYCC [3], int yccStep, IppiSize roiSize ))";
        readonly Method MethodE = new Method("IppStatus", "ippiBGRToYCoCg_8u16s_C3P3R",
            new Parameter[] { new Parameter("const Ipp8u*", "pBGR"), new Parameter("int", "bgrStep"), new Parameter("Ipp16s*", "pYCC", new StaticArraySize(new[] { 3 })), new Parameter("int", "yccStep"), new Parameter("IppiSize", "roiSize"), });

        const string MethodStringF = @"IPPAPI (IppStatus, ippiAlphaComp_16u_AP4R,( const Ipp16u* const pSrc1[4], int src1Step, const Ipp16u* const pSrc2[4], int src2Step, Ipp16u* const pDst[4], int dstStep, IppiSize roiSize, IppiAlphaType alphaType ))";
        readonly Method MethodF = new Method("IppStatus", "ippiAlphaComp_16u_AP4R",
            new Parameter[] { new Parameter("const Ipp16u* const", "pSrc1", new StaticArraySize(new[] { 4 })), new Parameter("int", "src1Step"), new Parameter("const Ipp16u* const", "pSrc2", new StaticArraySize(new[] { 4 })), new Parameter("int", "src2Step"), new Parameter("Ipp16u* const", "pDst", new StaticArraySize(new[] { 4 })), new Parameter("int", "dstStep"), new Parameter("IppiSize", "roiSize"), new Parameter("IppiAlphaType", "alphaType") });

        const string MethodStringG = @"IPPAPI ( IppStatus, ippiColorTwist_32f_P3R, ( const Ipp32f* pSrc[3], int srcStep, Ipp32f* pDst[3], int dstStep, IppiSize roiSize, const Ipp32f twist[3][4] ))";
        readonly Method MethodG = new Method("IppStatus", "ippiColorTwist_32f_P3R",
            new Parameter[] { new Parameter("const Ipp32f*", "pSrc", new StaticArraySize(new[] { 3 })), new Parameter("int", "srcStep"), new Parameter("Ipp32f*", "pDst", new StaticArraySize(new[] { 3 })), new Parameter("int", "dstStep"), new Parameter("IppiSize", "roiSize"), new Parameter("const Ipp32f", "twist", new StaticArraySize(new[] { 3, 4 })), });

        const string TypedefString0 = @"typedef enum {
    ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
    ippAffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
    ippAffinityAllEnabled,      /* KMP_AFFINITY=respect */
    ippAffinityRestore,
    ippTstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
    ippTstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */
} IppAffinityType;";
        readonly Typedef Typedef0 = new Typedef("enum", "IppAffinityType",
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
} IppiFilterBilateralType;";
        readonly Typedef Typedef1 = new Typedef("enum", "IppiFilterBilateralType",
                new string []{ "ippiFilterBilateralGauss = 100,",  "ippiFilterBilateralGaussFast = 101" }
            );

        const string TypedefString2 = @"typedef struct {
    Ipp32u borderLeft;
    Ipp32u borderTop;
    Ipp32u borderRight;
    Ipp32u borderBottom;
} IppiBorderSize;";
        readonly Typedef Typedef2 = new Typedef("struct", "IppiBorderSize",
                new string[] { "Ipp32u borderLeft;", "Ipp32u borderTop;", "Ipp32u borderRight;", "Ipp32u borderBottom;" }
            );

        [TestMethod]
        public void IppHelperTest_ParseMethodA()
        {
            var actual = IppHelper.ParseMethod(MethodStringA);

            Assert.AreEqual(MethodA, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseMethodB()
        {
            var actual = IppHelper.ParseMethod(MethodStringB);

            Assert.AreEqual(MethodB, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseMethodC()
        {
            var actual = IppHelper.ParseMethod(MethodStringC);

            Assert.AreEqual(MethodC, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseMethodD()
        {
            var actual = IppHelper.ParseMethod(MethodStringD);

            Assert.AreEqual(MethodD, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseMethodE()
        {
            var actual = IppHelper.ParseMethod(MethodStringE);

            Assert.AreEqual(MethodE, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseMethodF()
        {
            var actual = IppHelper.ParseMethod(MethodStringF);

            Assert.AreEqual(MethodF, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseMethodG()
        {
            var actual = IppHelper.ParseMethod(MethodStringG);

            Assert.AreEqual(MethodG, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseParameter()
        {
            Assert.AreEqual(new Parameter("const Ipp16u* const", "pSrc1", new StaticArraySize(new[] { 4 })), IppHelper.ParseParameter("const Ipp16u* const pSrc1[4]"));
            Assert.AreEqual(new Parameter("const double", "coeffs", new StaticArraySize(new[] { 2, 3 })), IppHelper.ParseParameter("const double coeffs[2][3]"));
            Assert.AreEqual(new Parameter("const Ipp8u **", "p"), IppHelper.ParseParameter("const Ipp8u *p[]"));
            Assert.AreEqual(new Parameter("Ipp16s*", "pYCC", new StaticArraySize(new[] { 3 })), IppHelper.ParseParameter(" Ipp16s* pYCC [3]"));
            Assert.AreEqual(new Parameter("unsigned int*", "pUMask"), IppHelper.ParseParameter(" unsigned int* pUMask "));
            Assert.AreEqual(new Parameter("IppiSize", "roiSize"), IppHelper.ParseParameter("IppiSize roiSize "));
            Assert.AreEqual(new Parameter("Ipp32fc *", "pDst"), IppHelper.ParseParameter("Ipp32fc *pDst"));
            Assert.AreEqual(new Parameter("const Ipp32f*", "pSrcMagn"), IppHelper.ParseParameter("const Ipp32f* pSrcMagn"));
            Assert.AreEqual(new Parameter("int", "srcStep"), IppHelper.ParseParameter("int srcStep"));
            Assert.AreEqual(new Parameter("int", "value", new StaticArraySize(new[] { 3 })), IppHelper.ParseParameter("int value[3]"));
        }

        [TestMethod]
        public void IppHelperTest_WrapMethodName()
        {
            Assert.AreEqual("GetLibVersion", IppHelper.WrapMethodName("ippGetLibVersion"));
            Assert.AreEqual("GetLibVersion", IppHelper.WrapMethodName("ippiGetLibVersion"));
            Assert.AreEqual("MulPack_32f_C4R", IppHelper.WrapMethodName("ippiMulPack_32f_C4R"));
            Assert.AreEqual("Test", IppHelper.WrapMethodName("ippsTest"));
        }

        [TestMethod]
        public void IppHelperTest_ParseTypedef0()
        {
            var actual = IppHelper.ParseTypedef(TypedefString0);

            Assert.AreEqual(Typedef0, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseTypedef1()
        {
            var actual = IppHelper.ParseTypedef(TypedefString1);

            Assert.AreEqual(Typedef1, actual);
        }

        [TestMethod]
        public void IppHelperTest_ParseTypedef2()
        {
            var actual = IppHelper.ParseTypedef(TypedefString2);

            Assert.AreEqual(Typedef2, actual);
        }

        [TestMethod]
        public void IppHelperTest_WrapTypedefName()
        {
            Assert.AreEqual("NIppiBorderSize", IppHelper.WrapTypedefName("IppiBorderSize"));
            Assert.AreEqual("NIppiPoint_32f", IppHelper.WrapTypedefName("IppiPoint_32f"));
            Assert.AreEqual("NIppiFilterBilateralType", IppHelper.WrapTypedefName("IppiFilterBilateralType"));
            Assert.AreEqual("NIppAffinityType", IppHelper.WrapTypedefName("IppAffinityType"));
            Assert.AreEqual("NIppsTest", IppHelper.WrapTypedefName("IppsTest"));
            Assert.AreEqual("NIpp8sc", IppHelper.WrapTypedefName("Ipp8sc"));
            Assert.AreEqual("NIpp64sc", IppHelper.WrapTypedefName("Ipp64sc"));
            Assert.AreEqual("NIpp64fc", IppHelper.WrapTypedefName("Ipp64fc"));
        }

        [TestMethod]
        public void IppHelperTest_WrapEnumValue()
        {
            Assert.AreEqual("AffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */", IppHelper.WrapEnumValue("ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */"));
            Assert.AreEqual("AffinityRestore,", IppHelper.WrapEnumValue("ippAffinityRestore,"));
        }
    }
}
