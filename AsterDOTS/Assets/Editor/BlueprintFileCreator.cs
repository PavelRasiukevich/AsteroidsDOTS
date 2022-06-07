using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Root
{
    public class BlueprintFileCreator
    {
        private const string componentName = "ComponentBlueprint";
        private const string systemName = "SystemBlueprint";
        private const string suffix = ".cs";

        [MenuItem("Tools/Create/Component")]
        public static void Component() => Perform(componentName);

        [MenuItem("Tools/Create/System")]
        public static void System() => Perform(systemName);

        private static void Perform(string nameOfBlueprint)
        {
            int numberOfMathingFilesName = GetNumberOfNameEntries(nameOfBlueprint);
            string name = nameOfBlueprint;

            if (numberOfMathingFilesName > 0)
                name = Rename(nameOfBlueprint, numberOfMathingFilesName);

            var path = BuildPath(name);
            var content = GetBlueprintContent(path);

            CreateBlueprint(path, content);
            RefreshHierarchy();
        }

        private static string GetBlueprintContent(string path)
        {
            var typeName = GetFileName(path);
            string content = "";

            if (typeName.Contains(systemName))
            {
                content = $"using Unity.Entities;\n\npublic partial class {typeName} : SystemBase\n{{\n\tprotected override void OnUpdate()\n\t{{\n\t}}\n}}\n";
            }
            else if (typeName.Contains(componentName))
            {
                content = $"using Unity.Entities;\n\n[GenerateAuthoringComponent]\npublic struct {typeName} : IComponentData\n{{\n}}\n";
            }

            return content;
        }

        private static string BuildPath(string name) =>
            Path.Combine(ValidatePath(SelectedObjectPathResolver.Resolve()), $"{name}{suffix}");

        private static string Rename(string name, int value) => $"{name}{value}";

        private static int GetNumberOfNameEntries(string name) => Directory
                            .GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
                            .Where(f => f.Contains(name)).ToArray().Length;

        private static string ValidatePath(string path)
        {
            var p = path;

            if (Path.GetExtension(path).Length > 0)
            {
                var t = Directory.GetParent(path);
                Selection.activeObject = null;
                p = t.FullName;
            }

            return p;
        }

        private static void CreateBlueprint(string path, string content)
        {
            using (FileStream fs = File.Create(path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }

        private static string GetFileName(string path) => Path.GetFileNameWithoutExtension(path);

        private static void RefreshHierarchy() => AssetDatabase.Refresh();
    }
}
