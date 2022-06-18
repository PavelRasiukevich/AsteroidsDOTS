using Unity.Entities;

[GenerateAuthoringComponent]
public struct KeyboardInput : IComponentData
{
    public float MoveValue;
}