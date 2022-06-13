using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "Names", menuName = "File Name SO")]
    public class FileConfig : ScriptableObject
    {
        public string ComponentName;
        public string SystemName;
        public string Suffix;
    }
}
