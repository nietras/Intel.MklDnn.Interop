using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn
{
    public class MklDnnTypedefParser
    {
        string m_currentTypedef = null;

        public IEnumerable<Typedef> ParseTypedefs(TextReader reader)
        {
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                line = line.Trim();

                if (line.StartsWith(CppHelper.Typedef))
                {
                    if (line.EndsWith("{"))
                    {
                        m_currentTypedef = line;

                        while (!(line.StartsWith("}") && line.EndsWith(";")))
                        {
                            line = reader.ReadLine().Trim();
                            m_currentTypedef += Environment.NewLine;
                            m_currentTypedef += line;
                        }

                        yield return MklDnnHelper.ParseTypedef(m_currentTypedef);
                    }
                    else if (line.EndsWith(";") && !line.Contains("[")) // Last checks if this is is an array typedef
                    {
                        var parts = line.Split(new []{' ', ';'}, StringSplitOptions.RemoveEmptyEntries);
                        var type = parts[1];
                        if (type == "struct")
                        {
                            var name = parts[3];
                            Debug.Assert(name.Length > 0);
                            yield return new Typedef("struct", name, new string[0]);
                        }
                        else if (type.StartsWith("MklDnn")) // Custom type forwarding from earlier typedef cannot do this in managed so just making new type
                        {
                            var name = parts[2];
                            Debug.Assert(name.Length > 0);
                            yield return new Typedef("struct", name, new string[0]);
                        }
                    }
                }
            }
        }
    }
}
