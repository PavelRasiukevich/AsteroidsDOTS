using Unity.Entities;

[DisableAutoCreation]
public partial class EnemySpawner : SystemBase
{
    private EndInitializationEntityCommandBufferSystem _endInitializationEntityCommandBufferSystem;

    protected override void OnCreate()
    {
        _endInitializationEntityCommandBufferSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var ecb = _endInitializationEntityCommandBufferSystem.CreateCommandBuffer();
        var deltaTime = Time.DeltaTime;

        Entities
        .ForEach((in EnemySpawnData spawnData) =>
    {

        var o = ecb.Instantiate(spawnData.Prefab);

        ecb.AddComponent(o, new EnemyData()
        {
            Acceleration = spawnData.Acceleration,
            Armor = spawnData.Armor,
            Health = spawnData.Health

        });

    }).Run();
    }
}

