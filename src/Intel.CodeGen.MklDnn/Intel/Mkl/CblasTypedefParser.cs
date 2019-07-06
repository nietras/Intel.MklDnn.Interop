using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public class CblasTypedefParser
    {
        string m_currentTypedef = null;

        public IEnumerable<Typedef> ParseTypedefs(TextReader reader)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();

                if (line.StartsWith(CSharpHelper.Typedef))
                {
                    m_currentTypedef = line;

                    while (!line.EndsWith(";"))
                    {
                        line = reader.ReadLine().Trim();
                        m_currentTypedef += Environment.NewLine;
                        m_currentTypedef += line;
                    }

                    yield return CblasHelper.ParseTypedef(m_currentTypedef);
                }
            }
        }
    }
}
