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
    public abstract class IppMethodParseTest
    {
        IppMethodParser m_parser = new IppMethodParser();

        public IEnumerable<Method> ParseMethodsInResource(string filename)
        {
            var reader = TestHelper.GetResourceReaderWhichEndsWith(filename);
            return m_parser.ParseMethods(reader);
        }
    }
}
