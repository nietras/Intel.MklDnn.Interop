using System;
using System.Diagnostics;
using System.Linq;

namespace Intel.CodeGen.MklDnn
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class Parameter : IEquatable<Parameter>
    {
        public readonly string Type;
        public readonly string DecoratedName;
        public readonly StaticArraySize StaticArraySize;

        public Parameter(string type, string decoratedName, StaticArraySize staticArraySize = null)
        {
            if (type == null) { throw new ArgumentNullException("type"); }
            if (decoratedName == null) { throw new ArgumentNullException("decoratedName"); }
            this.Type = type;
            this.DecoratedName = decoratedName;
            this.StaticArraySize = staticArraySize;

        }

        public string Name
        { get { return RemoveParameterDecoration(DecoratedName); } }

        public bool IsStaticArray
        { get { return this.StaticArraySize != null; } }

        public bool Equals(Parameter other)
        {
            if (other == null) { return false; }
            return this.Type.Equals(other.Type) &&
                   this.DecoratedName.Equals(other.DecoratedName) &&
                   this.IsStaticArray.Equals(other.IsStaticArray) &&
                   object.Equals(this.StaticArraySize, other.StaticArraySize);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parameter);
        }

        public override int GetHashCode()
        {
            return this.Type.GetHashCode() ^ this.DecoratedName.GetHashCode();
        }

        public override string ToString()
        {
            return DebuggerDisplay;
        }

        private string DebuggerDisplay
        { get { 
            var staticArraySuffix = this.IsStaticArray ? this.StaticArraySize.ToString() : string.Empty;
            return string.Format("{0} {1}{2}", Type, DecoratedName, staticArraySuffix); 
        } }

        public static string RemoveParameterDecoration(string parameterName)
        {
            // Replace pointer stuff if part of name
            parameterName = parameterName.Replace("*", string.Empty);

            var indexOfSuffix = parameterName.IndexOf('[');
            if (indexOfSuffix > 0)
            {
                return parameterName.Substring(0, indexOfSuffix);
            }
            return parameterName;
        }
    }
}
