using System;
using Unity.Entities;


[GenerateAuthoringComponent]
[Serializable]
public struct Wave : IComponentData
{
    public Entity Prefab;
    public int Amount;
    public float Frequency;
    public float TimeSinceLastFrame;

}
