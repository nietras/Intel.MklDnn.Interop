using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public class CblasMethodParser
    {
        string m_currentMethod = null;

        public IEnumerable<Method> ParseMethods(TextReader reader)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Length != 0 && char.IsLetter(line[0]) && line.Contains("("))
                {
                    m_currentMethod = line;
                    while (!m_currentMethod.EndsWith(";"))
                    {
                        m_currentMethod += " " + reader.ReadLine().Trim();
                    }
                    yield return CblasHelper.ParseMethod(m_currentMethod);
                }
            }
        }
    }
}
