using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Intel.CodeGen.MklDnn;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public class MklDnnTypeWrapperTest
    {
        MklDnnTypeWrapper m_wrapper = new MklDnnTypeWrapper(
              new Typedef("struct", "MklDnn8sc", new string[] { })
            , new Typedef("struct", "MklDnn32sc", new string[] { })
            , new Typedef("struct", "MklDnn32fc", new string[] { })
            , new Typedef("struct", "MklDnniPoint", new string[] { })
            , new Typedef("struct", "MklDnniPoint_32f", new string[] { })
            , new Typedef("struct", "MklDnnLibraryVersion", new string[] { }) // No lines needed here
            , new Typedef("enum", "MklDnnAffinityType", new string[] { }) // No lines needed here
            , new Typedef("struct", "MklDnniFFTSpec_C_32fc", new string[] { })
            );

        [TestMethod]
        public void MklDnnTypeWrapperTest_ShouldWrapType()
        {
            Assert.IsFalse(m_wrapper.ShouldWrapType("MklDnn8s"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("MklDnn8sc"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("MklDnnLibraryVersion"));
            Assert.IsTrue(m_wrapper.ShouldWrapType("MklDnnAffinityType"));
        }

        [TestMethod]
        public void MklDnnTypeWrapperTest_WrapType()
        {
            Assert.AreEqual("NMklDnniPoint", m_wrapper.WrapType("MklDnniPoint"));
            Assert.AreEqual("NMklDnniPoint_32f", m_wrapper.WrapType("MklDnniPoint_32f"));
            Assert.AreEqual("NMklDnn32fc*", m_wrapper.WrapType("const MklDnn32fc*"));
            Assert.AreEqual("MklDnn8s", m_wrapper.WrapType("MklDnn8s"));
            Assert.AreEqual("NMklDnn8sc", m_wrapper.WrapType("MklDnn8sc"));
            Assert.AreEqual("NMklDnnLibraryVersion", m_wrapper.WrapType("MklDnnLibraryVersion"));
            Assert.AreEqual("NMklDnnAffinityType", m_wrapper.WrapType("MklDnnAffinityType"));
            Assert.AreEqual("NMklDnnLibraryVersion*", m_wrapper.WrapType("const MklDnnLibraryVersion*"));
            Assert.AreEqual("NMklDnn32sc*", m_wrapper.WrapType("MklDnn32sc*"));
        }

        [TestMethod]
        public void MklDnnTypeWrapperTest_CastTypeToMgd()
        {
            Assert.AreEqual("p", m_wrapper.CastTypeToMgd("MklDnn8s", "p"));
            Assert.AreEqual("static_cast<NMklDnn8sc>(p)", m_wrapper.CastTypeToMgd("MklDnn8sc", "p"));
            Assert.AreEqual("static_cast<NMklDnnLibraryVersion>(p)", m_wrapper.CastTypeToMgd("MklDnnLibraryVersion", "p"));
            Assert.AreEqual("(NMklDnnLibraryVersion*)(p)", m_wrapper.CastTypeToMgd("const MklDnnLibraryVersion*", "p"));
            Assert.AreEqual("reinterpret_cast<NMklDnn32sc*>(p)", m_wrapper.CastTypeToMgd("MklDnn32sc*", "p"));
            Assert.AreEqual("static_cast<NMklDnnAffinityType>(p)", m_wrapper.CastTypeToMgd("MklDnnAffinityType", "p"));
        }

        [TestMethod]
        public void MklDnnTypeWrapperTest_CastTypeToNtv()
        {
            Assert.AreEqual("reinterpret_cast<MklDnniFFTSpec_C_32fc**>(p)", m_wrapper.CastTypeToNtv("NMklDnniFFTSpec_C_32fc**", "p"));
            //Assert.AreEqual("p", m_wrapper.CastTypeToNtv("const MklDnn32fc* pSrc", "p"));
            Assert.AreEqual("p", m_wrapper.CastTypeToNtv("MklDnn8s", "p"));
            Assert.AreEqual("*reinterpret_cast<MklDnn8sc*>(&p)", m_wrapper.CastTypeToNtv("NMklDnn8sc", "p"));
            Assert.AreEqual("*reinterpret_cast<MklDnnLibraryVersion*>(&p)", m_wrapper.CastTypeToNtv("NMklDnnLibraryVersion", "p"));
            Assert.AreEqual("static_cast<MklDnnLibraryVersion>(*p)", m_wrapper.CastTypeToNtv("const NMklDnnLibraryVersion*", "p"));
            Assert.AreEqual("reinterpret_cast<MklDnn32sc*>(p)", m_wrapper.CastTypeToNtv("NMklDnn32sc*", "p"));
            Assert.AreEqual("static_cast<MklDnnAffinityType>(p)", m_wrapper.CastTypeToNtv("NMklDnnAffinityType", "p"));
            Assert.AreEqual("*reinterpret_cast<MklDnniPoint*>(&p)", m_wrapper.CastTypeToNtv("NMklDnniPoint", "p"));
            Assert.AreEqual("*reinterpret_cast<MklDnniPoint_32f*>(&p)", m_wrapper.CastTypeToNtv("NMklDnniPoint_32f", "p"));
        }
    }
}
