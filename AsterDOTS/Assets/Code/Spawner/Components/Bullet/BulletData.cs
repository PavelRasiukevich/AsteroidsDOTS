using Unity.Entities;

[GenerateAuthoringComponent]
public struct BulletData : IComponentData
{
    public Entity Prefab;

    public int Damage;
    public float TravelSpeed;
    public float LifeDuration;
}