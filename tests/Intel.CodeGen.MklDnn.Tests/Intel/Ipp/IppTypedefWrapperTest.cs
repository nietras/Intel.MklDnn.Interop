using System;
using System.Linq;
using Intel.CodeGen.MklDnn.Ipp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppTypedefWrapperTest
    {
        // No lines necessary for this test
        IppTypedefWrapper m_wrapper = new IppTypedefWrapper(new Typedef("struct", "IppiRect", new string[] {  }));

        readonly Typedef TypedefA = new Typedef("struct", "IppiBorderSize",
                new string[] { "Ipp32u borderLeft;", "Ipp32u borderTop;", "Ipp32u borderRight;", "Ipp32u borderBottom;" }
            );
        const string TypedefStringA =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NIppiBorderSize
{
public:
    Ipp32u borderLeft;
    Ipp32u borderTop;
    Ipp32u borderRight;
    Ipp32u borderBottom;
};";

        readonly Typedef TypedefB = new Typedef("enum", "IppAffinityType",
                @"ippAffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
                ippAffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
                ippAffinityAllEnabled,      /* KMP_AFFINITY=respect */
                ippAffinityRestore,
                ippTstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
                ippTstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */"
                    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray()
            );
        const string TypedefStringB =
@"public enum class NIppAffinityType
{
    AffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
    AffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
    AffinityAllEnabled,      /* KMP_AFFINITY=respect */
    AffinityRestore,
    TstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
    TstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */
};";

        readonly Typedef TypedefC = new Typedef("struct", "Ipp8sc",
                new string[] { "Ipp8s  re;", "Ipp8s  im;" }
            );
        const string TypedefStringC =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NIpp8sc
{
public:
    Ipp8s  re;
    Ipp8s  im;
};";

        readonly Typedef TypedefD = new Typedef("struct", "IppiConnectedComp",
                new string[] { "Ipp64f area;    /*  area of the segmented component  */", 
                               "Ipp64f value[3];/*  gray scale value of the segmented component  */" ,
                               "IppiRect rect;    /*  bounding rectangle of the segmented component  */" ,
                }
            );
        const string TypedefStringD =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NIppiConnectedComp
{
public:
    Ipp64f area;    /*  area of the segmented component  */
    Ipp64f value0;
    Ipp64f value1;
    Ipp64f value2;
    NIppiRect rect;    /*  bounding rectangle of the segmented component  */
};";

        readonly Typedef TypedefE = new Typedef("struct", "AnyTypeJustIntendedAsPointerUse", new string[] {  } );
        const string TypedefStringE =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NAnyTypeJustIntendedAsPointerUse
{
public:
};";

        [TestMethod]
        public void IppTypedefWrapperTest_WrapTypedefA()
        {
            var actual = m_wrapper.WrapTypedef(TypedefA);
            Assert.AreEqual(TypedefStringA, actual);
        }

        [TestMethod]
        public void IppTypedefWrapperTest_WrapTypedefB()
        {
            var actual = m_wrapper.WrapTypedef(TypedefB);
            Assert.AreEqual(TypedefStringB, actual);
        }

        [TestMethod]
        public void IppTypedefWrapperTest_WrapTypedefC()
        {
            var actual = m_wrapper.WrapTypedef(TypedefC);
            Assert.AreEqual(TypedefStringC, actual);
        }

        [TestMethod]
        public void IppTypedefWrapperTest_WrapTypedefD()
        {
            var actual = m_wrapper.WrapTypedef(TypedefD);
            Assert.AreEqual(TypedefStringD, actual);
        }

        [TestMethod]
        public void IppTypedefWrapperTest_WrapTypedefE()
        {
            var actual = m_wrapper.WrapTypedef(TypedefE);
            Assert.AreEqual(TypedefStringE, actual);
        }
    }
}
