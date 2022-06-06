using Unity.Entities;

[GenerateAuthoringComponent]
public struct Blueprint : IComponentData
{
    public Entity Value;
}
