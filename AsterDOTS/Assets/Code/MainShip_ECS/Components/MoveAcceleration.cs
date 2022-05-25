using Unity.Entities;
using Unity.Transforms;

[WriteGroup(typeof(Translation))]
[GenerateAuthoringComponent]
public struct MoveAcceleration : IComponentData
{
    public float Value;
}