using Unity.Entities;

[GenerateAuthoringComponent]
public struct KeyboardInput : IComponentData
{
    public float RotationValue;
    public float MoveValue;
    public float AttackValue;
}