using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class InputListener : SystemBase
{
    private CustomInput _customInput;
    private InputAction _moveInputAction;
    private InputAction _rotateInputAction;

    protected override void OnCreate()
    {
        _customInput = new CustomInput();
        _customInput.Enable();

        _moveInputAction = _customInput.SpaceShip_AM.Move;
        _rotateInputAction = _customInput.SpaceShip_AM.Rotate;
    }

    protected override void OnUpdate()
    {
        var m_Value = _moveInputAction.ReadValue<Vector2>().y;
        var r_Value = _rotateInputAction.ReadValue<Vector2>().x;

        Entities.ForEach((ref KeyboardInput input) =>
        {
            input.MoveValue = m_Value;
            input.RotationValue = r_Value;
            
        }).Run();
    }

    protected override void OnDestroy()
    {
        _customInput.Disable();
    }
}
