using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public class LapackeMethodParser
    {
        string m_currentMethod = null;

        public IEnumerable<Method> ParseMethods(TextReader reader)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(LapackeHelper.LapackeMethodPrefix) && char.IsLetter(line[0]))
                {
                    m_currentMethod = line;
                    while (!m_currentMethod.EndsWith(";"))
                    {
                        m_currentMethod += " " + reader.ReadLine().Trim();
                    }
                    yield return LapackeHelper.ParseMethod(m_currentMethod);
                }
            }
        }
    }
}
