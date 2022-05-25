using Unity.Entities;
using UnityEngine;

[GenerateAuthoringComponent]
public struct KeyboardInput : IComponentData
{
    public float RotationValue;
    public float MoveValue;
}