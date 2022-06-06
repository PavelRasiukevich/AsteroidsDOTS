using System.IO;
using System.Linq;
using UnityEditor;

namespace Root
{
    public class FolderHierarchy_ECS
    {
        private const string blueprint = "ECS Hierarchy Blueprint";

        private const string c = "Components";
        private const string s = "Systems";
        private const string j = "Jobs";
        private const string e = "Entities";

        [MenuItem("Tools/Create/ECS Folders Setup")]
        public static void PerformMenuAction()
        {
            ValidateDirCreation(blueprint, c, s, j, e);
        }

        //improve
        //not clear what the method does
        private static void ValidateDirCreation(string rootDirName, params string[] dirNames)
        {

            string activeObjectPath = SelectedObjectPathResolver.Resolve();

            if (IsExistInCurrentPath(activeObjectPath, rootDirName))
                CreateDirsBlueprint(GetExtendedDirName(activeObjectPath), dirNames, activeObjectPath);
            else
                CreateDirsBlueprint(rootDirName, dirNames, activeObjectPath);

        }

        private static void CreateDirsBlueprint(string rootDirName, string[] dirNames, string activeObjectPath)
        {
            foreach (var dirName in dirNames)
            {
                var fullPath = Combine(Combine(activeObjectPath, rootDirName), dirName);
                Directory.CreateDirectory(fullPath);
                AssetDatabase.Refresh();
            }
        }

        private static bool IsExistInCurrentPath(string path, string rootDirName)
        {
            return Directory.Exists(Combine(path, rootDirName));
        }

        public static string GetExtendedDirName(string path)
        {
            var allNamesMatches = Directory.GetDirectories(path)
                                    .Where(dir => dir.Contains(blueprint))
                                    .ToArray();

            return $"{blueprint} {allNamesMatches.Length}";
        }

        private static string Combine(string p1, string p2)
        {
            return Path.Combine(p1, p2);
        }
    }
}
