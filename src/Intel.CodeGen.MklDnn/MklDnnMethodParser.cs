using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn
{
    public class MklDnnMethodParser
    {
        bool m_nextMethodDeprecated = false;
        string m_currentMethod = null;

        public IEnumerable<Method> ParseMethods(TextReader reader)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(MklDnnHelper.MKLDNNAPI))
                {
                    m_currentMethod = line;
                    while (!m_currentMethod.EndsWith(";"))
                    {
                        m_currentMethod += " " + reader.ReadLine().Trim();
                    }
                    if (!m_nextMethodDeprecated)
                    {
                        yield return MklDnnHelper.ParseMethod(m_currentMethod);
                    }
                    else
                    {
                        m_nextMethodDeprecated = false;
                    }
                }
                else if (line.StartsWith(MklDnnHelper.MKLDNN_DEPRECATED))
                {
                    m_nextMethodDeprecated = true;
                }
            }
        }
    }
}
