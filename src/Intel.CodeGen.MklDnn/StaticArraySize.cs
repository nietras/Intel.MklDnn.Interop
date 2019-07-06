using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class StaticArraySize : IEquatable<StaticArraySize>
    {
        public readonly IReadOnlyList<int> Sizes;

        public StaticArraySize(IReadOnlyList<int> sizes)
        {
            if (sizes == null) { throw new ArgumentNullException("sizes"); }
            this.Sizes = sizes;
        }

        public bool Equals(StaticArraySize other)
        {
            if (other == null) { return false; }
            return this.Sizes.SequenceEqual(other.Sizes);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as StaticArraySize);
        }

        public override int GetHashCode()
        {
            return this.Sizes.GetHashCode();
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay
        {
            get
            {
                var staticArraySuffix = this.Sizes.Select(s => "[" + s + "]").Aggregate((a, b) => a + b);
                return staticArraySuffix;
            }
        }

    }
}
