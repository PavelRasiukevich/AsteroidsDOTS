using Unity.Entities;

[GenerateAuthoringComponent]
public struct DeltaTime : IComponentData
{
    public float Value;
}