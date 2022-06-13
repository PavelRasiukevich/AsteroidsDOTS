using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Linq;

namespace Root
{
    public sealed class BlueprintFileCreator
    {
        private static readonly string[] configs = AssetDatabase.FindAssets("t:FileConfig");
        private static readonly FileConfig _config = (FileConfig)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(configs[0]), typeof(FileConfig));

        [MenuItem("Tools/Test")]
        public static void T()
        {
            Debug.Log(_config.ComponentName);
        }

        [MenuItem("Tools/Create/Component")]
        public static void Component() => Perform(_config.ComponentName);

        [MenuItem("Tools/Create/System")]
        public static void System() => Perform(_config.SystemName);

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

            if (typeName.Contains(_config.SystemName))
                content = $"using Unity.Entities;\n\npublic partial class {typeName} : SystemBase\n{{\n\tprotected override void OnUpdate()\n\t{{\n\t}}\n}}";

            else if (typeName.Contains(_config.ComponentName))
                content = $"using Unity.Entities;\n\n[GenerateAuthoringComponent]\npublic struct {typeName} : IComponentData\n{{\n}}";

            content.TrimStart(' ');
            content.TrimEnd(' ');

            return content;
        }

        private static string BuildPath(string name) =>
            Path.Combine(ValidatePath(SelectedObjectPathResolver.Resolve()), $"{name}{_config.Suffix}");

        private static string Rename(string name, int value) => $"{name}{value}";

        private static int GetNumberOfNameEntries(string name) => Directory
                            .GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
                            .Where(f => f.Contains(name)).ToArray().Length;

        private static string ValidatePath(string path)
        {
            if (Path.GetExtension(path).Length > 0)
                Selection.activeObject = null;

            return Directory.GetParent(path).FullName;
        }

        private static void CreateBlueprint(string path, string content)
        {
            using FileStream fs = File.Create(path);
            byte[] info = new UTF8Encoding(true).GetBytes(content);
            fs.Write(info, 0, info.Length);
        }

        private static string GetFileName(string path) => Path.GetFileNameWithoutExtension(path);

        private static void RefreshHierarchy() => AssetDatabase.Refresh();
    }
}
