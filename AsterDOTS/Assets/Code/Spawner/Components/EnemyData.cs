using Unity.Entities;

[GenerateAuthoringComponent]
public struct EnemyData : IComponentData
{
    public Acceleration Acceleration;
    public Health Health;
    public Armor Armor;
}
