using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "Config", menuName = "Blueprint Config")]
    public class FileConfig : ScriptableObject
    {
        [field: SerializeField] public string ComponentName { get; private set; }

        [field: SerializeField] public string SystemName { get; private set; }

        [field: SerializeField] public string Suffix { get; private set; }
    }
}
