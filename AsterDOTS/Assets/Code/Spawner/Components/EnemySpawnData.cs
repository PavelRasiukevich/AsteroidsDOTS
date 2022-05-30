using Unity.Entities;

[GenerateAuthoringComponent]
public struct EnemySpawnData : IComponentData
{
    public Entity Prefab;
    public Health Health;
    public Armor Armor;
    public Acceleration Acceleration;
}
