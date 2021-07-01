using System;
using System.IO;
using GeneratorLib;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentPath = new DirectoryInfo(Environment.CurrentDirectory);
            var projectPath = currentPath.Parent.Parent.Parent.Parent;
            var schemaPath = Path.Combine(projectPath.FullName, "glTF", "specification", "2.0", "schema", "glTF.schema.json");

            Console.WriteLine("Assuming glTF schema is here: " + schemaPath);

            var generator = new CodeGenerator(schemaPath);
            generator.ParseSchemas();
            generator.ExpandSchemaReferences();
            generator.EvaluateInheritance();
            generator.PostProcessSchema();
            var outputDirPath = Path.Combine(projectPath.FullName, "glTFLoader", "Schema");

            Console.WriteLine("Writing generated schemas here: " + outputDirPath);

            generator.CSharpCodeGen(Path.GetFullPath(outputDirPath));
        }
    }
}
