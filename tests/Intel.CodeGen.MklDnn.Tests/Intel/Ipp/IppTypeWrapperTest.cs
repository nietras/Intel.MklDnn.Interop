using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intel.CodeGen.MklDnn.Ipp;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public class IppTypeWrapperTest
    {
        IppTypeWrapper m_wrapper = new IppTypeWrapper(
              new Typedef("struct", "Ipp8sc", new string[] { })
            , new Typedef("struct", "Ipp32sc", new string[] { })
            , new Typedef("struct", "Ipp32fc", new string[] { })
            , new Typedef("struct", "IppiPoint", new string[] { })
            , new Typedef("struct", "IppiPoint_32f", new string[] { })
            , new Typedef("struct", "IppLibraryVersion", new string[] { }) // No lines needed here
            , new Typedef("enum", "IppAffinityType", new string[] { }) // No lines needed here
            , new Typedef("struct", "IppiFFTSpec_C_32fc", new string[] { })
            );

        [TestMethod]
        public void IppTypeWrapperTest_ShouldWrapType()
        {
            Assert.IsFalse(m_wrapper.ShouldWrapType("Ipp8s"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("Ipp8sc"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("IppLibraryVersion"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("IppAffinityType"));
        }

        [TestMethod]
        public void IppTypeWrapperTest_WrapType()
        {
            Assert.AreEqual("NIppiPoint", m_wrapper.WrapType("IppiPoint"));
            Assert.AreEqual("NIppiPoint_32f", m_wrapper.WrapType("IppiPoint_32f"));
            Assert.AreEqual("NIpp32fc*", m_wrapper.WrapType("const Ipp32fc*"));
            Assert.AreEqual("Ipp8s", m_wrapper.WrapType("Ipp8s"));
            Assert.AreEqual("NIpp8sc", m_wrapper.WrapType("Ipp8sc"));
            Assert.AreEqual("NIppLibraryVersion", m_wrapper.WrapType("IppLibraryVersion"));
            Assert.AreEqual("NIppAffinityType", m_wrapper.WrapType("IppAffinityType"));
            Assert.AreEqual("NIppLibraryVersion*", m_wrapper.WrapType("const IppLibraryVersion*"));
            Assert.AreEqual("NIpp32sc*", m_wrapper.WrapType("Ipp32sc*"));
        }

        [TestMethod]
        public void IppTypeWrapperTest_CastTypeToMgd()
        {
            Assert.AreEqual("p", m_wrapper.CastTypeToMgd("Ipp8s", "p"));
            Assert.AreEqual("static_cast<NIpp8sc>(p)", m_wrapper.CastTypeToMgd("Ipp8sc", "p"));
            Assert.AreEqual("static_cast<NIppLibraryVersion>(p)", m_wrapper.CastTypeToMgd("IppLibraryVersion", "p"));
            Assert.AreEqual("(NIppLibraryVersion*)(p)", m_wrapper.CastTypeToMgd("const IppLibraryVersion*", "p"));
            Assert.AreEqual("reinterpret_cast<NIpp32sc*>(p)", m_wrapper.CastTypeToMgd("Ipp32sc*", "p"));
            Assert.AreEqual("static_cast<NIppAffinityType>(p)", m_wrapper.CastTypeToMgd("IppAffinityType", "p"));
        }

        [TestMethod]
        public void IppTypeWrapperTest_CastTypeToNtv()
        {
            Assert.AreEqual("reinterpret_cast<IppiFFTSpec_C_32fc**>(p)", m_wrapper.CastTypeToNtv("NIppiFFTSpec_C_32fc**", "p"));
            //Assert.AreEqual("p", m_wrapper.CastTypeToNtv("const Ipp32fc* pSrc", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("Ipp8s", "p"));
            Assert.AreEqual("*reinterpret_cast<Ipp8sc*>(&p)", m_wrapper.CastTypeToNtv("NIpp8sc", "p"));
            Assert.AreEqual("*reinterpret_cast<IppLibraryVersion*>(&p)", m_wrapper.CastTypeToNtv("NIppLibraryVersion", "p"));
            Assert.AreEqual("static_cast<IppLibraryVersion>(*p)", m_wrapper.CastTypeToNtv("const NIppLibraryVersion*", "p"));
            Assert.AreEqual("reinterpret_cast<Ipp32sc*>(p)", m_wrapper.CastTypeToNtv("NIpp32sc*", "p"));
            Assert.AreEqual("static_cast<IppAffinityType>(p)", m_wrapper.CastTypeToNtv("NIppAffinityType", "p"));
            Assert.AreEqual("*reinterpret_cast<IppiPoint*>(&p)", m_wrapper.CastTypeToNtv("NIppiPoint", "p"));
            Assert.AreEqual("*reinterpret_cast<IppiPoint_32f*>(&p)", m_wrapper.CastTypeToNtv("NIppiPoint_32f", "p"));
        }
    }
}
