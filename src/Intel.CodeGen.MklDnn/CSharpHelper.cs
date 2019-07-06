using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn
{
    public class CSharpHelper
    {
        public const string Typedef = "typedef";

        public static string WrapTypedefType(string nativeType)
        {
            //if (nativeType == "struct")
            //{ return "struct"; }
            //else if (nativeType == "enum")
            //{ return "enum"; }
            return nativeType;
        }

        public static bool IsIdentifierChar(char c)
        {
            return char.IsLetterOrDigit(c) || c == '_';
        }
    }
}
