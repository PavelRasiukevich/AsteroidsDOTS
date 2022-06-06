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

            var validatedPath = ValidatePath(selectedObjectInProjectHierarchyPath);

            var containBlueprintName = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
                .Where(f => f.Contains(fileName)).ToArray();

            if (containBlueprintName.Length > 0)
            {
                var nameOfTheCopy = $"{fileName}{containBlueprintName.Length}";
                CreateFile(Path.Combine(validatedPath, $"{nameOfTheCopy}{suffix}"));
                RefreshHierarchy();
            }
            else
            {
                CreateFile(Path.Combine(validatedPath, $"{fileName}{suffix}"));
                RefreshHierarchy();
            }
        }

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

        private static void CreateFile(string path)
        {
            using (FileStream fs = File.Create(path))
            {
                var content = $"using Unity.Entities;\n\n[GenerateAuthoringComponent]\npublic struct {GetFileName(path)} : IComponentData\n{{\n}}\n";
                byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }

        private static string GetFileName(string path) => Path.GetFileNameWithoutExtension(path);

        private static void RefreshHierarchy() => AssetDatabase.Refresh();
    }
}
