using Unity.Entities;

[GenerateAuthoringComponent]
public struct Wave : IComponentData
{
    public Entity Prefab;
    public int Amount;
    public float Frequency;
    public float TimeSinceLastFrame;

}
