using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class InputListener : SystemBase
{
    private CustomInput _customInput;
    private InputAction _moveInputAction;

    private EntityQuery _queryKeyboardInput;
    private ListenToInputJob _listenToInputJob;

    protected override void OnCreate()
    {
        _customInput = new CustomInput();
        _customInput.Enable();

        _moveInputAction = _customInput.SpaceShip_AM.Move;

        _queryKeyboardInput = GetEntityQuery(typeof(KeyboardInput));
        _listenToInputJob = new ListenToInputJob();
    }

    protected override void OnUpdate()
    {
        _listenToInputJob.MoveValue = _moveInputAction.ReadValue<Vector2>().x;

        _listenToInputJob.Run(_queryKeyboardInput);
    }

    protected override void OnDestroy()
    {
        _customInput.Disable();
    }
}