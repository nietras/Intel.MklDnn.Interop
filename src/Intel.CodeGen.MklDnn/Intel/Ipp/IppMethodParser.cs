using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Ipp
{
    public class IppMethodParser
    {
        bool m_nextMethodDeprecated = false;
        string m_currentMethod = null;

        public IEnumerable<Method> ParseMethods(TextReader reader)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith(IppHelper.IPPAPI))
                {
                    m_currentMethod = line;
                    while (!(m_currentMethod.EndsWith("))") || m_currentMethod.EndsWith(") )")))
                    {
                        m_currentMethod += " " + reader.ReadLine().Trim();
                    }
                    if (!m_nextMethodDeprecated)
                    {
                        yield return IppHelper.ParseMethod(m_currentMethod);
                    }
                    else
                    {
                        m_nextMethodDeprecated = false;
                    }
                }
                else if (line.StartsWith(IppHelper.IPP_DEPRECATED))
                {
                    m_nextMethodDeprecated = true;
                }
            }
        }
    }
}
