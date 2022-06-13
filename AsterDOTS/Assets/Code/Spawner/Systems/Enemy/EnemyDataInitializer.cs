using Unity.Entities;

public partial class EnemyDataInitializer : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .ForEach((ref EnemySpawnData enemySpawnData) =>
        {
            enemySpawnData.Armor.Value = 10;
            enemySpawnData.Health.Value = 100;
            enemySpawnData.Acceleration.MoveAccelerationValue = 10;
            enemySpawnData.Acceleration.RotateAccelerationValue = 2;

        }).Run();
    }
}


