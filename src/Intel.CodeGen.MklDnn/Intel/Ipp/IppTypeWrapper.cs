using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Ipp
{
    public class IppTypeWrapper
    {
        readonly IReadOnlyList<Typedef> m_typedefs;

        public IppTypeWrapper(params Typedef[] typedefs)
            : this(typedefs as IReadOnlyList<Typedef>)
        { }

        public IppTypeWrapper(IReadOnlyList<Typedef> typedefs)
        {
            if (typedefs == null) { throw new ArgumentNullException("typedefs"); }
            m_typedefs = typedefs;
        }

        public bool ShouldWrapType(string ippName)
        {
            var typedef = TryFindTypedefNtv(ippName);
            return typedef != null;
        }

        public string WrapType(string ippName)
        {
            var typedef = TryFindTypedefNtv(ippName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(ippName);
                //if (typeUsage.HasConst)
                //{
                //    return IppHelper.WrapTypedefName(typeUsage.NameOnly);
                //}
                //else
                {
                    return IppHelper.WrapTypedefName(typeUsage.RemoveConst());
                }
            }
            return ippName;
        }

        public string CastTypeToMgd(string ippName, string content)
        {
            var typedef = TryFindTypedefNtv(ippName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(ippName);
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
            return IppHelper.WrapTypedefName(typeUsage.NameOnly);
        }

        private Typedef TryFindTypedefNtv(string ippName)
        {
            var typedefs = m_typedefs.Where(t => ippName.Contains(t.Name)).OrderByDescending(t => t.Name.Length).ToArray();
            if (typedefs.Any())
            {
                return typedefs.First();
            }
            return null;
        }

        private Typedef TryFindTypedefMgd(string mgdName)
        {
            var typedefs = m_typedefs.Where(t => mgdName.Contains(IppHelper.WrapTypedefName(t.Name))).OrderByDescending(t => t.Name.Length).ToArray(); ;
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
            { get { return RemoveConst().KeepAlphaNumeric(); } }

            public bool HasConst
            { get { return m_type.StartsWith("const "); } }

            public string RemoveConst()
            { return m_type.Replace("const ", string.Empty); }
        }
    }
}
