using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppiTypedefParseTest : IppTypedefParseTest
    {
        readonly Typedef Typedef0 = new Typedef("enum", "IppiAlphaType",     
                @"    ippAlphaOver,
    ippAlphaIn,
    ippAlphaOut,
    ippAlphaATop,
    ippAlphaXor,
    ippAlphaPlus,
    ippAlphaOverPremul,
    ippAlphaInPremul,
    ippAlphaOutPremul,
    ippAlphaATopPremul,
    ippAlphaXorPremul,
    ippAlphaPlusPremul"
                    .Split(new []{ Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray()
            );
        readonly Typedef Typedef10 = new Typedef("struct", "IppiBorderSize",
                new string[] { "Ipp32u borderLeft;", "Ipp32u borderTop;", "Ipp32u borderRight;", "Ipp32u borderBottom;" }
            );

        readonly Typedef Typedef1 = new Typedef("struct", "IppiDeconvFFTState_32f_C1R", new string[0]);

        readonly Typedef Typedef30 = new Typedef("enum", "IppiAxis", @"ippAxsHorizontal,
            ippAxsVertical,
            ippAxsBoth,
            ippAxs45,
            ippAxs135".Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray());

        [TestMethod]
        public void IppiTypedefParseTest_ParseTypedefsInResource()
        {
            var typedefs = ParseTypedefsInResource("ippi.h").ToList();
            Assert.AreEqual(Typedef0, typedefs[0]);
            Assert.AreEqual(Typedef1, typedefs[1]);
            Assert.AreEqual(Typedef10, typedefs[10]);
            Assert.AreEqual(Typedef30, typedefs[30]);
            Assert.AreEqual(33, typedefs.Count); // Update when ipp changes, do check
        }
    }
}
