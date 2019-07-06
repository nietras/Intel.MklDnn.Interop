using System;
using System.Linq;
using Intel.CodeGen.MklDnn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class MklDnnTypedefWrapperTest
    {
        // No lines necessary for this test
        MklDnnTypedefWrapper m_wrapper = new MklDnnTypedefWrapper(new Typedef("struct", "MklDnniRect", new string[] {  }));

        readonly Typedef TypedefA = new Typedef("struct", "MklDnniBorderSize",
                new string[] { "MklDnn32u borderLeft;", "MklDnn32u borderTop;", "MklDnn32u borderRight;", "MklDnn32u borderBottom;" }
            );
        const string TypedefStringA =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NMklDnniBorderSize
{
public:
    MklDnn32u borderLeft;
    MklDnn32u borderTop;
    MklDnn32u borderRight;
    MklDnn32u borderBottom;
};";

        readonly Typedef TypedefB = new Typedef("enum", "MklDnnAffinityType",
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
@"public enum class NMklDnnAffinityType
{
    AffinityCompactFineCore, /* KMP_AFFINITY=granularity=fine,compact,n,offset, where n - level */
    AffinityCompactFineHT,   /* KMP_AFFINITY=granularity=fine,compact,0,offset */
    AffinityAllEnabled,      /* KMP_AFFINITY=respect */
    AffinityRestore,
    TstAffinityCompactFineCore, /* test mode for affinity type ippAffinityCompactFineCore */
    TstAffinityCompactFineHT    /* test mode for affinity type ippAffinityCompactFineHT   */
};";

        readonly Typedef TypedefC = new Typedef("struct", "MklDnn8sc",
                new string[] { "MklDnn8s  re;", "MklDnn8s  im;" }
            );
        const string TypedefStringC =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NMklDnn8sc
{
public:
    MklDnn8s  re;
    MklDnn8s  im;
};";

        readonly Typedef TypedefD = new Typedef("struct", "MklDnniConnectedComp",
                new string[] { "MklDnn64f area;    /*  area of the segmented component  */", 
                               "MklDnn64f value[3];/*  gray scale value of the segmented component  */" ,
                               "MklDnniRect rect;    /*  bounding rectangle of the segmented component  */" ,
                }
            );
        const string TypedefStringD =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NMklDnniConnectedComp
{
public:
    MklDnn64f area;    /*  area of the segmented component  */
    MklDnn64f value0;
    MklDnn64f value1;
    MklDnn64f value2;
    NMklDnniRect rect;    /*  bounding rectangle of the segmented component  */
};";

        readonly Typedef TypedefE = new Typedef("struct", "AnyTypeJustIntendedAsPointerUse", new string[] {  } );
        const string TypedefStringE =
@"[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]
public value struct NAnyTypeJustIntendedAsPointerUse
{
public:
};";

        [TestMethod]
        public void MklDnnTypedefWrapperTest_WrapTypedefA()
        {
            var actual = m_wrapper.WrapTypedef(TypedefA);
            Assert.AreEqual(TypedefStringA, actual);
        }

        [TestMethod]
        public void MklDnnTypedefWrapperTest_WrapTypedefB()
        {
            var actual = m_wrapper.WrapTypedef(TypedefB);
            Assert.AreEqual(TypedefStringB, actual);
        }

        [TestMethod]
        public void MklDnnTypedefWrapperTest_WrapTypedefC()
        {
            var actual = m_wrapper.WrapTypedef(TypedefC);
            Assert.AreEqual(TypedefStringC, actual);
        }

        [TestMethod]
        public void MklDnnTypedefWrapperTest_WrapTypedefD()
        {
            var actual = m_wrapper.WrapTypedef(TypedefD);
            Assert.AreEqual(TypedefStringD, actual);
        }

        [TestMethod]
        public void MklDnnTypedefWrapperTest_WrapTypedefE()
        {
            var actual = m_wrapper.WrapTypedef(TypedefE);
            Assert.AreEqual(TypedefStringE, actual);
        }
    }
}
