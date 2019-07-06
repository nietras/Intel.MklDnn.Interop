using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Intel.CodeGen.MklDnn
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class Typedef : IEquatable<Typedef>
    {
        public readonly string Type;
        public readonly string Name;
        public readonly IReadOnlyList<string> Lines;

        public Typedef(string type, string name, IReadOnlyList<string> lines)
        {
            if (type == null) { throw new ArgumentNullException("type"); }
            if (name == null) { throw new ArgumentNullException("name"); }
            if (lines == null) { throw new ArgumentNullException("lines"); }

            this.Type = type;
            this.Name = name;
            this.Lines = lines;
        }

        public bool IsEnum
        { get { return this.Type == "enum"; } }

        public bool IsStruct
        { get { return this.Type == "struct"; } }

        public bool Equals(Typedef other)
        {
            if (other == null) { return false; }
            return this.Type.Equals(other.Type) &&
                   this.Name.Equals(other.Name) &&
                   this.Lines.SequenceEqual(other.Lines);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Typedef);
        }

        public override int GetHashCode()
        {
            return this.Type.GetHashCode() ^ this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay 
        { get{ return string.Format("{0} {1}({2})", Type, Name, string.Join(Environment.NewLine, Lines)); } }
    }
}
