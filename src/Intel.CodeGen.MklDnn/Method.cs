using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Intel.CodeGen.MklDnn
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class Method : IEquatable<Method>
    {
        public readonly string ReturnType;
        public readonly string Name;
        public readonly IReadOnlyList<Parameter> Parameters;

        public Method(string returnType, string name, IReadOnlyList<Parameter> parameters)
        {
            if (returnType == null) { throw new ArgumentNullException("returnType"); }
            if (name == null) { throw new ArgumentNullException("name"); }
            if (parameters == null) { throw new ArgumentNullException("parameters"); }

            this.ReturnType = returnType;
            this.Name = name;
            this.Parameters = parameters;
        }

        public bool Equals(Method other)
        {
            if (other == null) { return false; }
            return this.ReturnType.Equals(other.ReturnType) &&
                   this.Name.Equals(other.Name) &&
                   this.Parameters.SequenceEqual(other.Parameters);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Method);
        }

        public override int GetHashCode()
        {
            return this.ReturnType.GetHashCode() ^ this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay 
        { get{ return string.Format("{0} {1}({2})", ReturnType, Name, string.Join(", ", Parameters.Select(p => p.Type + " " + p.DecoratedName))); } }
    }
}
