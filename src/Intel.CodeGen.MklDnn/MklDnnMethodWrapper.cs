using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intel.CodeGen.MklDnn
{
    public class MklDnnMethodWrapper
    {
        readonly MklDnnTypeWrapper m_wrapper;
        StringBuilder m_sb = new StringBuilder();

        public MklDnnMethodWrapper()
            : this(new MklDnnTypeWrapper())
        { }

        public MklDnnMethodWrapper(MklDnnTypeWrapper wrapper)
        {
            if (wrapper == null) { throw new ArgumentNullException("wrapper"); }
            m_wrapper = wrapper;
        }

        public string WrapMethod(Method method)
        {
            m_sb.Clear();

            var mgdReturnType = m_wrapper.WrapType(method.ReturnType);
            var mgdParameters = method.Parameters.Select(p => (p.IsStaticArray ? p.Type.Replace("const", string.Empty).Trim() + "*" : m_wrapper.WrapType(p.Type)) + " " + p.DecoratedName);
            m_sb.AppendFormat("{0} {1}({2})", mgdReturnType, MklDnnHelper.WrapMethodName(method.Name),
                                              string.Join(", ", mgdParameters));
            m_sb.AppendLine();

            if (method.Parameters.Any(p => p.IsStaticArray))
            {
                m_sb.AppendLine("{");

                var staticArrayParameters = method.Parameters.Where(p => p.IsStaticArray).ToArray();
                foreach (var staticArrayParameter in staticArrayParameters)
                {
                    WrapStaticArray(staticArrayParameter, m_sb);
                }

                var castParametersToNative = method.Parameters.Select(p => p.IsStaticArray ? p.Name + "_" : m_wrapper.CastTypeToNtv(m_wrapper.WrapType(p.Type), p.Name));
                var methodCall = string.Format("{0}({1})", method.Name, string.Join(", ", castParametersToNative));
                m_sb.AppendFormat("    return {0};", m_wrapper.CastTypeToMgd(method.ReturnType, methodCall));
                m_sb.AppendLine();
                m_sb.Append("}");
            }
            else
            {

                var castParametersToNative = method.Parameters.Select(p => m_wrapper.CastTypeToNtv(m_wrapper.WrapType(p.Type), p.Name));

                var methodCall = string.Format("{0}({1})", method.Name, string.Join(", ", castParametersToNative));
                m_sb.AppendFormat("{{    return {0}; }}", m_wrapper.CastTypeToMgd(method.ReturnType, methodCall));
            }
            return m_sb.ToString();
        }

        private static string StaticArrayParameter(Parameter p)
        {
            var type = p.Type;
            if (type.Contains("*"))
            {
                const string constText = "const";
                if (type.EndsWith(constText))
                {
                    return type.Substring(0, type.Length - constText.Length).Trim();
                }
                return type; // Static array of pointers
            }
            else
            {
                // Static array basic so remove const
                return type.Replace("const", string.Empty).Trim();
            }
        }

        private void WrapStaticArray(Parameter p, StringBuilder sb)
        {
            var sizes = p.StaticArraySize.Sizes;
            // MklDnn16u value_[3];
            var staticArrayName = p.Name + "_";
            sb.AppendFormat("    {0} {1}{2};", StaticArrayParameter(p), staticArrayName, sizes.Select(s => "[" + s + "]").Aggregate((a, b) => a + b));
            sb.AppendLine();
            // auto valuePtr = &value_[0];
            var ptrName = p.Name + "Ptr";
            sb.AppendFormat("    auto {0} = &{1}{2};", ptrName, staticArrayName, Enumerable.Repeat("[0]", sizes.Count).Aggregate((a, b) => a + b));
            sb.AppendLine();
            // for (int i = 0; i < 3; ++i) { value_[i] = value[i]; }
            sb.AppendFormat("    for (int i = 0; i < {0}; ++i) {{ {1}[i] = {2}[i]; }}", string.Join("*", sizes), ptrName, p.Name);
            sb.AppendLine();
        }
    }
}
