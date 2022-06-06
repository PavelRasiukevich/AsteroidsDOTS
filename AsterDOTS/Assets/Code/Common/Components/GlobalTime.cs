using Unity.Entities;

[GenerateAuthoringComponent]
public struct GlobalTime : IComponentData
{
    public int Time;
}
