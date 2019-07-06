using System.Collections.Generic;

namespace Intel.CodeGen.MklDnn
{
    public class NameTypedefEqualityComparer : IEqualityComparer<Typedef>
    {
        public bool Equals(Typedef x, Typedef y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Typedef o)
        {
            return o.Name.GetHashCode();
        }
    }
}
