﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn
{
    public class MklDnnTypeWrapper
    {
        readonly IReadOnlyList<Typedef> m_typedefs;

        public MklDnnTypeWrapper(params Typedef[] typedefs)
            : this(typedefs as IReadOnlyList<Typedef>)
        { }

        public MklDnnTypeWrapper(IReadOnlyList<Typedef> typedefs)
        {
            if (typedefs == null) { throw new ArgumentNullException("typedefs"); }
            m_typedefs = typedefs;
        }

        public bool ShouldWrapType(string mklDnnName)
        {
            var typedef = TryFindTypedefNtv(mklDnnName);
            return typedef != null;
        }

        public string WrapType(string mklDnnName)
        {
            var typedef = TryFindTypedefNtv(mklDnnName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(mklDnnName);
                //if (typeUsage.HasConst)
                //{
                //    return MklDnnHelper.WrapTypedefName(typeUsage.NameOnly);
                //}
                //else
                {
                    return MklDnnHelper.WrapTypedefName(typeUsage.RemoveConst());
                }
            }
            return mklDnnName;
        }

        public string CastTypeToMgd(string mklDnnName, string content)
        {
            var typedef = TryFindTypedefNtv(mklDnnName);
            if (typedef != null)
            {
                var typeUsage = new TypeUsage(mklDnnName);
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
            return MklDnnHelper.WrapTypedefName(typeUsage.NameOnly);
        }

        private Typedef TryFindTypedefNtv(string mklDnnName)
        {
            var typedefs = m_typedefs.Where(t => mklDnnName.Contains(t.Name)).OrderByDescending(t => t.Name.Length).ToArray();
            if (typedefs.Any())
            {
                return typedefs.First();
            }
            return null;
        }

        private Typedef TryFindTypedefMgd(string mgdName)
        {
            var typedefs = m_typedefs.Where(t => mgdName.Contains(MklDnnHelper.WrapTypedefName(t.Name))).OrderByDescending(t => t.Name.Length).ToArray(); ;
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
