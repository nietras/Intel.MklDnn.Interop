using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public class CblasTypedefWrapper
    {
        //readonly IReadOnlyList<Typedef> m_typedefs;
        StringBuilder m_sb = new StringBuilder();

        //public MklDnnTypedefWrapper(params Typedef[] typedefs)
        //    : this(typedefs as IReadOnlyList<Typedef>)
        //{ }

        public CblasTypedefWrapper()//IReadOnlyList<Typedef> typedefs)
        {
            //if (typedefs == null) { throw new ArgumentNullException("typedefs"); }
            //m_typedefs = typedefs;
        }

        public string WrapTypedef(Typedef typedef)
        {
            m_sb.Clear();

            if (typedef.IsStruct)
            {
                m_sb.AppendLine("[System::Runtime::InteropServices::StructLayout(System::Runtime::InteropServices::LayoutKind::Sequential)]");
            }
            m_sb.AppendFormat("public {0} {1}", CppHelper.WrapTypedefType(typedef.Type), CblasHelper.WrapTypedefName(typedef.Name));
            m_sb.AppendLine();
            m_sb.AppendLine("{");
            if (typedef.IsStruct)
            {
                m_sb.AppendLine("public:");
            }
            foreach (var line in typedef.Lines)
            {
                var newLine = line;
                //var typedefMatching = m_typedefs.Where(t => line.StartsWith(t.Name)).SingleOrDefault();
                //if (typedefMatching != null)
                //{
                //    newLine = MklDnnHelper.WrapTypedefName(line);
                //}
                //else 
                if(typedef.IsEnum)
                {
                    newLine = CblasHelper.WrapEnumValue(line);
                }
                m_sb.AppendLine("    " + newLine);
            }
            m_sb.Append("};");

            return m_sb.ToString();
        }
    }
}
