using Unity.Entities;

public partial class SpecifyEnemyData : SystemBase
{
    protected override void OnUpdate()
    {

        Entities
            .WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
            .ForEach((ref EnemySpawnData enemySpawnData, in Blueprint blueprint, in ButtonInput input) =>
        {
            if (input.IsPressed)
            {
                Init(ref enemySpawnData, blueprint);
            }
        }).WithoutBurst().Run();

        //система не отработает если не найдется ни одной энтити с тэгом Ranger
        RequireForUpdate(GetEntityQuery(typeof(RangerTag)));
    }

    //пересмотреть подход
    public static void Init(ref EnemySpawnData enemySpawnData, Blueprint blueprint, int mult = 1)
    {
        enemySpawnData.Armor.Value = 10 * mult;
        enemySpawnData.Health.Value = 100;
        enemySpawnData.Acceleration.MoveAccelerationValue = 10;
        enemySpawnData.Acceleration.RotateAccelerationValue = 2;
        enemySpawnData.Prefab = blueprint.Form_1;
    }
}

public partial class TankSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithAll<TankTag>()
            .ForEach((ref EnemySpawnData enemySpawnData, in ButtonInput input, in Blueprint blueprint) =>
        {
            if (input.IsPressed)
            {
                SpecifyEnemyData.Init(ref enemySpawnData, blueprint, 2);
            }
        }).WithoutBurst().Run();
    }
}

