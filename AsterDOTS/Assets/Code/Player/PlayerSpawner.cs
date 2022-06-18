using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject dummyTarget;

    public int w_divider;
    public int h_divider;

    private void Awake()
    {
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(PlayerPrefab, settings);

        var manager = World.DefaultGameObjectInjectionWorld.EntityManager;

        var e = manager.Instantiate(prefab);

        //compute spawn point position

        var spawnPoint_X_Value = Screen.width / w_divider;
        var spawnPoint_Y_Value = Screen.height / h_divider;

        var vectorUsingScreenValues = new Vector2(spawnPoint_X_Value, spawnPoint_Y_Value);

        Debug.Log($"Vector With Screen Values:{ vectorUsingScreenValues}");

        var stwp = Camera.main.ScreenToWorldPoint(new Vector3(spawnPoint_X_Value, spawnPoint_Y_Value, 15));

        Debug.Log($"Vector converted from screen to world point:{ stwp}");

        manager.SetComponentData(e, new Translation() { Value = stwp });

    }

    private void Update()
    {
    }
}
