using Unity.Entities;
using UnityEngine.InputSystem;

[GenerateAuthoringComponent]
public struct ButtonInput : IComponentData
{
    public bool IsPressed => Keyboard.current.qKey.wasPressedThisFrame;
}
