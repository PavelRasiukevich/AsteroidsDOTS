using Unity.Entities;
using UnityEngine.InputSystem;

public partial class Spawner : SystemBase
{

    protected override void OnStartRunning()
    {
    }

    protected override void OnUpdate()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Entities
            .WithStructuralChanges()
            .ForEach((in EnemySpawnData spawnData) =>
            {

                for (int i = 0; i < 1; i++)
                {
                    var newEnemy = EntityManager.Instantiate(spawnData.Prefab);

                    var enemyDataComponent = EntityManager.AddComponentData(newEnemy, new EnemyData
                    {
                        Acceleration = spawnData.Acceleration,
                        Armor = spawnData.Armor,
                        Health = spawnData.Health
                    }); ;
                }

            }).Run();
        }
    }
}
