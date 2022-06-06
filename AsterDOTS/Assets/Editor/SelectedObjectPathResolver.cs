using UnityEditor;
using UnityEngine;

namespace Root
{
    public class SelectedObjectPathResolver
    {
        public static string Resolve()
        {
            var obj = Selection.activeObject;
            return obj != null ? AssetDatabase.GetAssetPath(obj.GetInstanceID()) : Application.dataPath;
        }
    }
}
