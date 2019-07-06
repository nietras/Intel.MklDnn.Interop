using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn
{
    public static class StringExtensions
    {
        public static string KeepAlphaNumeric(this string text)
        {
            var arr = Array.FindAll(text.ToCharArray(), (c => (char.IsLetterOrDigit(c) || c == '-')));
            return new string(arr);
        }
        public static string KeepAlphaNumericUnderscore(this string text)
        {
            var arr = Array.FindAll(text.ToCharArray(), (c => (char.IsLetterOrDigit(c) || c == '-') || c == '_'));
            return new string(arr);
        }
    }
}
