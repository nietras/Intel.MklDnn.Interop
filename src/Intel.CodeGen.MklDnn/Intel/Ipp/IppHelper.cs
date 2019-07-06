using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intel.CodeGen.MklDnn.Ipp
{
    public static class IppHelper
    {
        public const string IPPAPI = "IPPAPI";
        public const string IPP_DEPRECATED = "IPP_DEPRECATED";

        public static Method ParseMethod(string methodString)
        {
            var majorParts = IppSplit(methodString, '(').Skip(1);
            var methodParts =IppSplit(majorParts.First(), ',');
            var argsParts = IppSplit(majorParts.Skip(1).Single().Replace(")", string.Empty), ',');

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
            while (!char.IsLetterOrDigit(text[nameEndIndex])) { --nameEndIndex; }
            var nameStartIndex = nameEndIndex;
            while (char.IsLetterOrDigit(text[nameStartIndex])) { --nameStartIndex; }
            ++nameStartIndex;

            var typeText = text.Substring(0, nameStartIndex).Trim();
            var name = text.Substring(nameStartIndex, nameEndIndex - nameStartIndex + 1);

            var arraySizes = arraySuffixCount > 0 ? text.Substring(anyArrayStartIndex).Replace("]", string.Empty)
                                                        .Split(new []{'['}, StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToArray()
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

        public static string WrapMethodName(string ippName)
        {
            int index = 0;
            while (char.IsLower(ippName[index])) { ++index; }
            return ippName.Substring(index);
        }

        public static Typedef ParseTypedef(string typedefString)
        {
            var typedefLines = typedefString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var type = IppSplit(typedefLines[0], ' ')[1].Trim();
            var name = typedefLines.Last().KeepAlphaNumericUnderscore();
            var lines = typedefLines.Skip(1).Take(typedefLines.Length - 2).Select(s => s.Trim()).ToArray();
            return new Typedef(type, name, lines);
        }

        private static string[] IppSplit(string text, char separator)
        {
            return text.Split(separator).Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s.Trim()).ToArray();
        }

        public static string WrapTypedefName(string ippName)
        {
            return "N" + ippName;
        }

        public static string WrapEnumValue(string ippName)
        {
            int index = 0;
            while (char.IsLower(ippName[index])) { ++index; }
            return ippName.Substring(index);
        }

    }
}
