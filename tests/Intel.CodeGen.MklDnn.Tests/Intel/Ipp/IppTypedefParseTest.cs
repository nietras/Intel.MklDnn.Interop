using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Intel.CodeGen.MklDnn.Ipp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test.Intel.Ipp
{
    [TestClass]
    public abstract class IppTypedefParseTest
    {
        IppTypedefParser m_parser = new IppTypedefParser();

        public IEnumerable<Typedef> ParseTypedefsInResource(string filename)
        {
            var reader = TestHelper.GetResourceReaderWhichEndsWith(filename);
            return m_parser.ParseTypedefs(reader);
        }
    }
}
