using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public class CblasTypeWrapper
    {
        readonly IReadOnlyList<Typedef> m_typedefs;

        public CblasTypeWrapper(params Typedef[] typedefs)
            : this(typedefs as IReadOnlyList<Typedef>)
        { }

        public CblasTypeWrapper(IReadOnlyList<Typedef> typedefs)
        {
            if (typedefs == null) { throw new ArgumentNullException("typedefs"); }
            m_typedefs = typedefs;
        }

        public bool ShouldWrapType(string ntvName)
        {
            var typedef = TryFindTypedefNtv(ntvName);
            return typedef != null;
        }

        public string WrapType(string ntvName, string methodName = "")
        {
            var typedef = TryFindTypedefNtv(ntvName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(ntvName);
                {
                    return CblasHelper.WrapTypedefName(typeUsage.RemoveConst());
                }
            }
            else if (ntvName.Contains("void") && methodName.Length > 0)
            {
                ntvName = ntvName.Replace("const ", string.Empty);
                methodName = methodName.Replace("cblas_", string.Empty);
                if (methodName.StartsWith("dc") || methodName.StartsWith("z") || methodName.StartsWith("dz")) // complex 64-bit
                {
                    return ntvName.Replace("void", MklConstants.MklComplex16);
                }
                else if (methodName.StartsWith("sc") || methodName.StartsWith("c") || methodName.StartsWith("sc")) // complex 32-bit
                {
                    return ntvName.Replace("void", MklConstants.MklComplex8);
                }
            }
            return ntvName;
        }

        public string CastTypeToMgd(string ntvName, string content)
        {
            var typedef = TryFindTypedefNtv(ntvName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(ntvName);
                if (typeUsage.HasPointer)
                {
                    if (typeUsage.HasConst)
                    {
                        return string.Format("({0}*)({1})", WrapTypeUsage(typeUsage), content);
                    }
                    else
                    {
                        return string.Format("reinterpret_cast<{0}*>({1})", WrapTypeUsage(typeUsage), content);
                    }
                }
                else
                {
                    return string.Format("static_cast<{0}>({1})", WrapTypeUsage(typeUsage), content);
                }
            }
            return content;
        }

        public string CastTypeToNtv(string mgdName, string content)
        {
            var typedef = TryFindTypedefMgd(mgdName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(mgdName);
                if (typeUsage.HasPointer)
                {
                    if (typeUsage.HasConst)
                    {
                        return string.Format("static_cast<{0}>(*{1})", typedef.Name, content);
                    }
                    else
                    {
                        return string.Format("reinterpret_cast<{0}{1}>({2})", typedef.Name, typeUsage.Pointers, content);
                    }
                }
                else
                {
                    if (typedef.IsEnum)
                    {
                        return string.Format("static_cast<{0}>({1})", typedef.Name, content);
                    }
                    return string.Format("*reinterpret_cast<{0}*>(&{1})", typedef.Name, content);
                }
            }
            return content;
        }

        private string WrapTypeUsage(TypeUsage typeUsage)
        {
            return CblasHelper.WrapTypedefName(typeUsage.NameOnly);
        }

        private Typedef TryFindTypedefNtv(string ntvName)
        {
            var typedefs = m_typedefs.Where(t => ntvName.Contains(t.Name)).OrderByDescending(t => t.Name.Length).ToArray();
            if (typedefs.Any())
            {
                return typedefs.First();
            }
            return null;
        }

        private Typedef TryFindTypedefMgd(string mgdName)
        {
            var typedefs = m_typedefs.Where(t => mgdName.Contains(CblasHelper.WrapTypedefName(t.Name))).OrderByDescending(t => t.Name.Length).ToArray(); ;
            if (typedefs.Any())
            {
                return typedefs.First();
            }
            return null;
        }

        class TypeUsage
        {
            readonly string m_type;

            public TypeUsage(string type)
            {
                m_type = type;
            }

            public bool HasPointer
            { get { return m_type.Contains("*"); } }

            public string Pointers
            { get { return new string(Enumerable.Repeat('*', m_type.ToCharArray().Count(c => c == '*')).ToArray()); } }

            public string NameOnly
            { get { return RemoveConst().KeepAlphaNumericUnderscore(); } }

            public bool HasConst
            { get { return m_type.StartsWith("const "); } }

            public string RemoveConst()
            { return m_type.Replace("const ", string.Empty); }
        }
    }
}
