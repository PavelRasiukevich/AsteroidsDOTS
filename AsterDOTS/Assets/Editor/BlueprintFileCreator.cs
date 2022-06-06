using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Root
{
    public class BlueprintFileCreator
    {
        private const string fileName = "ComponentBlueprint";
        private const string suffix = ".cs";

        [MenuItem("Tools/Create/Struct")]
        public static void Boo()
        {
            var selectedObjectInProjectHierarchyPath = SelectedObjectPathResolver.Resolve();

            var containBlueprintName = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
                .Where(f => f.Contains(fileName)).ToArray();

            if (containBlueprintName.Length > 0)
            {
                var nameOfTheCopy = $"{fileName}{containBlueprintName.Length}";
                CreateFile(Path.Combine(selectedObjectInProjectHierarchyPath, $"{nameOfTheCopy}{suffix}"));
                RefreshHierarchy();
            }
            else
            {
                CreateFile(Path.Combine(selectedObjectInProjectHierarchyPath, $"{fileName}{suffix}"));
                RefreshHierarchy();
            }
        }

        private static void CreateFile(string path)
        {
            using (FileStream fs = File.Create(path))
            {
                var content = $"using Unity.Entities;\n\n[GenerateAuthoringComponent]\npublic struct {GetFileNameFromPath(path)} : IComponentData\n{{\n}}\n";
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }

        private static string GetFileNameFromPath(string path)
        {
            var start = path.IndexOf("\\");
            var end = path.IndexOf(".");
            start += 1;
            var length = end - start;

            return path.Substring(start, length);
        }

        private static void RefreshHierarchy() => AssetDatabase.Refresh();
    }
}
