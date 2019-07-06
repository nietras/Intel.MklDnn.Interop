using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public class LapackeTypeWrapper
    {
        readonly IReadOnlyList<Typedef> m_typedefs;

        public LapackeTypeWrapper(params Typedef[] typedefs)
            : this(typedefs as IReadOnlyList<Typedef>)
        { }

        public LapackeTypeWrapper(IReadOnlyList<Typedef> typedefs)
        {
            if (typedefs == null) { throw new ArgumentNullException("typedefs"); }
            m_typedefs = typedefs;
        }

        public bool ShouldWrapType(string ntvName)
        {
            var typedef = TryFindTypedefNtv(ntvName);
            return typedef != null;
        }

        public string WrapType(string ntvName)
        {
            var typedef = TryFindTypedefNtv(ntvName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(ntvName);
                {
                    return LapackeHelper.WrapTypedefName(typeUsage.RemoveConst());
                }
            }
            else if (ntvName.Contains(LapackeHelper.LapackComplexFloatType))
            {
                return ntvName.Replace("const ", string.Empty).Replace(LapackeHelper.LapackComplexFloatType, MklConstants.MklComplex8);
            }
            else if (ntvName.Contains(LapackeHelper.LapackComplexDoubleType))
            {
                return ntvName.Replace("const ", string.Empty).Replace(LapackeHelper.LapackComplexDoubleType, MklConstants.MklComplex16);
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
            if (typedef == null)
            {
                if (mgdName.Contains(MklConstants.MklComplex8))
                {
                    mgdName = mgdName.Replace("const ", string.Empty);
                    typedef = new Typedef("struct", LapackeHelper.LapackComplexFloatType, new string[0]);
                }
                else if (mgdName.Contains(MklConstants.MklComplex16))
                {
                    mgdName = mgdName.Replace("const ", string.Empty);
                    typedef = new Typedef("struct", LapackeHelper.LapackComplexDoubleType, new string[0]);
                }
            }
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(mgdName);
                if (typeUsage.HasPointer)
                {
                    return string.Format("reinterpret_cast<{0}{1}{2}>({3})", typeUsage.HasConst ? "const " : string.Empty, typedef.Name, typeUsage.Pointers, content);
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
            return LapackeHelper.WrapTypedefName(typeUsage.NameOnly);
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
            var typedefs = m_typedefs.Where(t => mgdName.Contains(LapackeHelper.WrapTypedefName(t.Name))).OrderByDescending(t => t.Name.Length).ToArray(); ;
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
