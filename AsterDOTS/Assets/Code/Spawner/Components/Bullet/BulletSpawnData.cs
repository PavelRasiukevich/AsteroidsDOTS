using Unity.Entities;

[GenerateAuthoringComponent]
public struct BulletSpawnData : IComponentData
{
    public Entity Prefab;

    public int Damage;
    public float TravelSpeed;
    public float LifeDuration;
}