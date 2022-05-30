using Unity.Entities;

[GenerateAuthoringComponent]
public struct NonEmptyComponent : IComponentData
{
    public bool Value;
}