using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Intel.CodeGen.MklDnn;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    [TestClass]
    public abstract class MklDnnMethodParseBaseTest
    {
        MklDnnMethodParser m_parser = new MklDnnMethodParser();

        public IEnumerable<Method> ParseMethodsInResource(string filename)
        {
            var reader = TestHelper.GetResourceReaderWhichEndsWith(filename);
            return m_parser.ParseMethods(reader);
        }
    }
}
