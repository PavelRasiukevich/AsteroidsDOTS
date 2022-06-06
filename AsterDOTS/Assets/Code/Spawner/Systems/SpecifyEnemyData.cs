using Unity.Entities;

public partial class SpecifyEnemyData : SystemBase
{
    protected override void OnUpdate()
    {

        var hasBeenSet = false;

        Entities
            .WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
            .ForEach((ref EnemySpawnData enemySpawnData, in Wave wave, in GlobalTime global) =>
        {

            enemySpawnData.Armor.Value = 10;
            enemySpawnData.Health.Value = 100;
            enemySpawnData.Acceleration.MoveAccelerationValue = 10;
            enemySpawnData.Acceleration.RotateAccelerationValue = 2;

            enemySpawnData.Prefab = wave.Prefab;

        }).Run();
    }
}

[DisableAutoCreation]
public partial class TankSystem : SystemBase
{
    protected override void OnUpdate()
    {
    }
}

