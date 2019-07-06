using System;
using System.Linq;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intel.CodeGen.MklDnn.Test
{
    public static class TestHelper
    {
        public static TextReader GetResourceReaderWhichEndsWith(string end)
        {
            var asm = Assembly.GetExecutingAssembly();
            var name = asm.GetManifestResourceNames().Single(n => n.EndsWith(end));
            var stream = asm.GetManifestResourceStream(name);
            var reader = new StreamReader(stream);
            return reader;
        }
    }
}
