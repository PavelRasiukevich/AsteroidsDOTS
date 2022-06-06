using Unity.Entities;
using UnityEngine;

public partial class Spawner : SystemBase
{
    private EndInitializationEntityCommandBufferSystem _endInitializationEntityCommandBufferSystem;

    protected override void OnCreate()
    {
        _endInitializationEntityCommandBufferSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
    }

    protected override void OnStartRunning()
    {
    }

    protected override void OnUpdate()
    {

        var ecb = _endInitializationEntityCommandBufferSystem.CreateCommandBuffer();

        var deltaTime = Time.DeltaTime;

        Entities
        .ForEach((ref Wave wave, in EnemySpawnData spawnData) =>
    {

        if (wave.TimeSinceLastFrame >= wave.Frequency)
        {

            var newEnemy = ecb.Instantiate(spawnData.Prefab);

            ecb.AddComponent(newEnemy, new EnemyData
            {
                Acceleration = spawnData.Acceleration,
                Armor = spawnData.Armor,
                Health = spawnData.Health
            }); ;

            wave.TimeSinceLastFrame = 0.0f;
        }
        else
        {
            wave.TimeSinceLastFrame += deltaTime;
        }

    }).Run();
    }

}

