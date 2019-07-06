﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intel.CodeGen.MklDnn.Ipp
{
    public class IppTypedefWrapper
    {
        readonly IReadOnlyList<Typedef> m_typedefs;
        StringBuilder m_sb = new StringBuilder();

        public IppTypedefWrapper(params Typedef[] typedefs)
            : this(typedefs as IReadOnlyList<Typedef>)
        { }

        public IppTypedefWrapper(IReadOnlyList<Typedef> typedefs)
        {
            if (typedefs == null) { throw new ArgumentNullException("typedefs"); }
            m_typedefs = typedefs;
        }

        public string WrapTypedef(Typedef typedef)
        {
            m_sb.Clear();

            if (typedef.IsStruct)
            {
                m_sb.AppendLine("[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]");
            }
            m_sb.AppendFormat("public {0} {1}", CppHelper.WrapTypedefType(typedef.Type), IppHelper.WrapTypedefName(typedef.Name));
            m_sb.AppendLine();
            m_sb.AppendLine("{");
            if (typedef.IsStruct)
            {
                m_sb.AppendLine("public:");
            }
            foreach (var line in typedef.Lines)
            {
                // Hack
                if (line.Contains("targetCpu[4]"))
                {
                    m_sb.AppendLine("    " + "char targetCpu0;");
                    m_sb.AppendLine("    " + "char targetCpu1;");
                    m_sb.AppendLine("    " + "char targetCpu2;");
                    m_sb.AppendLine("    " + "char targetCpu3;");
                }
                else if (line.Contains("value[3]"))
                {
                    m_sb.AppendLine("    " + "Ipp64f value0;");
                    m_sb.AppendLine("    " + "Ipp64f value1;");
                    m_sb.AppendLine("    " + "Ipp64f value2;");
                }
                else
                {
                    var newLine = line;
                    var typedefMatching = m_typedefs.Where(t => line.StartsWith(t.Name)).SingleOrDefault();
                    if (typedefMatching != null)
                    {
                        newLine = IppHelper.WrapTypedefName(line);
                    }
                    else if(typedef.IsEnum && typedef.Name != "IppDataType")
                    {
                        newLine = IppHelper.WrapEnumValue(line);
                    }
                    m_sb.AppendLine("    " + newLine);
                }
            }
            m_sb.Append("};");

            return m_sb.ToString();
        }
    }
}
