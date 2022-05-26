using Unity.Entities;

[GenerateAuthoringComponent]
public struct Acceleration : IComponentData
{
    public float MoveAccelerationValue;
    public float RotateAccelerationValue;
}