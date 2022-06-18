using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

//Enable when make camera work
[DisableAutoCreation]
public partial class BulletSpawner : SystemBase
{
    private EndInitializationEntityCommandBufferSystem _endInitializationEntityCommandBufferSystem;
    //private EnemySpawner _enemySpawnerTest;
    private EntityQuery _query;

    protected override void OnCreate()
    {

        //_enemySpawnerTest = World.GetOrCreateSystem<EnemySpawner>();

        _query = GetEntityQuery(typeof(BulletSpawnData));
        _endInitializationEntityCommandBufferSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
    }

    protected override void OnStartRunning()
    {
        //_enemySpawnerTest.Update();
    }

    protected override void OnUpdate()
    {

        var ecb = _endInitializationEntityCommandBufferSystem.CreateCommandBuffer();

        NativeArray<Translation> na = new(1, Allocator.Temp);

        Translation tr = new();

        Entities
          .WithAll<PlayerTag>()
          .ForEach((in Translation translation) =>
          {
              tr = translation;

          }).Run();

        Entities.ForEach((in BulletSpawnData bulletSpawnData) =>
        {
            var e = ecb.Instantiate(bulletSpawnData.Prefab);

            ecb.SetComponent(e, tr);

        }).Run();
    }
}

public partial class BulletMover : SystemBase
{
    protected override void OnUpdate()
    {
        var t = Time.DeltaTime;

        NativeArray<Translation> na = new NativeArray<Translation>(1, Allocator.Temp);

        Entities
            .WithAll<BulletTag>()
            .ForEach((Entity e, int entityInQueryIndex, ref Translation translation) =>
            {
                var movement = new float3()
                {
                    x = 0,
                    y = 0,
                    z = 2 * t
                };

                translation.Value += movement;

                na[0] = translation;

            }).Run();
    }
}


