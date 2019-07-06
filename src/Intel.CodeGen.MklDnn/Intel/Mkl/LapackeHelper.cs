using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Mkl
{
    public static class LapackeHelper
    {
        public const string LapackComplexFloatType = "lapack_complex_float";
        public const string LapackComplexDoubleType = "lapack_complex_double";
        public const string LapackeMethodPrefix = "LAPACKE_";

        public static Typedef ParseTypedef(string typedefString)
        {
            var typedefLines = typedefString.Split(new[] { "{", "}" }, StringSplitOptions.RemoveEmptyEntries);
            var type = Split(typedefLines[0], ' ')[1].Trim();
            var name = typedefLines.Last().KeepAlphaNumericUnderscore();
            var lines = typedefLines.Skip(1).Take(typedefLines.Length - 2).Select(s => s.Trim()).ToArray();
            return new Typedef(type, name, lines);
        }

        public static Method ParseMethod(string nativeMethod)
        {
            var majorParts = Split(nativeMethod, '(');
            var methodParts = Split(majorParts.First(), ' ');
            var argsParts = Split(majorParts.Skip(1).Single().Replace(")", string.Empty).Replace(";", string.Empty), ',');

            var returnType = methodParts.First();
            var name = methodParts.Skip(1).Single();
            var parameters = ParseParameters(argsParts);

            return new Method(returnType, name, parameters);
        }

        private static Parameter[] ParseParameters(IEnumerable<string> parameters)
        {
            if (parameters.Count() == 1 && parameters.Single() == "void")
            {
                return new Parameter[0];
            }
            return parameters.Select(p => ParseParameter(p)).ToArray();
        }

        public static Parameter ParseParameter(string text)
        {
            var asteriskCount = text.ToCharArray().Count(c => c == '*');
            var arraySuffixCount = text.ToCharArray().Count(c => c == '[');
            var anyArrayStartIndex = text.IndexOf('[');
            var newLength = anyArrayStartIndex > 0 ? anyArrayStartIndex : text.Length;
            var nameEndIndex = newLength - 1;
            while (!CppHelper.IsIdentifierChar(text[nameEndIndex])) { --nameEndIndex; }
            var nameStartIndex = nameEndIndex;
            while (CppHelper.IsIdentifierChar(text[nameStartIndex])) { --nameStartIndex; }
            ++nameStartIndex;

            var typeText = text.Substring(0, nameStartIndex).Trim();
            var name = text.Substring(nameStartIndex, nameEndIndex - nameStartIndex + 1);

            var arraySizes = arraySuffixCount > 0 ? text.Substring(anyArrayStartIndex).Replace("]", string.Empty)
                                                        .Split(new[] { '[' }, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray()
                                                  : new int[0];
            if (arraySuffixCount == arraySizes.Length && asteriskCount == 0 && arraySizes.Length > 0)
            {
                // Static array
                return new Parameter(typeText, name, new StaticArraySize(arraySizes));
            }
            else
            {
                arraySuffixCount -= arraySizes.Length; // Only subtract those more than 1
                var type = typeText + new string(Enumerable.Repeat<char>('*', arraySuffixCount).ToArray());
                return new Parameter(type, name, arraySizes.Length > 0 ? new StaticArraySize(arraySizes) : null);
            }
        }

        public static string WrapTypedefName(string nativeName)
        {
            return nativeName.Trim().Split('_').Select(s => s.Substring(0, 1) + s.Substring(1).ToLower()).Aggregate((a, b) => a + b);
        }

        public static string WrapMethodName(string nativeName)
        {
            return nativeName.Replace(LapackeMethodPrefix, string.Empty);
        }

        public static string WrapEnumValue(string nativeValue)
        {
            return nativeValue;
        }

        private static string[] Split(string text, char separator)
        {
            return text.Split(separator).Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()).ToArray();
        }
    }
}
