using System;
using System.IO;
using System.Linq;
using CppSharp;
using CppSharp.AST;
using CppSharp.Generators;

namespace CodeGenCppSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleDriver.Run(new MklDnnLibrary());
        }
    }

    public class MklDnnLibrary : ILibrary
    {
        public void Setup(Driver driver)
        {
            var includeDir = @"..\..\headers";

            var driverOptions = driver.Options;
            driverOptions.GeneratorKind = GeneratorKind.CSharp;
            driverOptions.OutputDir = @"..\..\codegen";

            var parserOptions = driver.ParserOptions;
            parserOptions.AddIncludeDirs(includeDir);
            //parserOptions.AddArguments("-fcxx-exceptions");

            var module = driverOptions.AddModule("mkldnn");
            module.OutputNamespace = "Intel.MklDnn";
            module.IncludeDirs.Add(includeDir);
            var headers = Directory.EnumerateFiles(includeDir, "*.h").ToArray();
            foreach (var header in headers)
            {
                module.Headers.Add(Path.GetFileName(header));
            }
        }

        public void SetupPasses(Driver driver)
        {

        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {
        }
    }
}
