using Unity.Entities;
using Unity.Transforms;

public partial class PlayerMovement : SystemBase
{
    private EntityQuery _playerMovementSystemQuery;
    private MovePlayerJob _movePlayerJob;

    protected override void OnUpdate()
    {
        _playerMovementSystemQuery = GetEntityQuery(typeof(PlayerTag));

        _movePlayerJob = new MovePlayerJob
        {
            RotationTypeHandler = GetComponentTypeHandle<Rotation>(false),
            TranslationTypeHandler = GetComponentTypeHandle<Translation>(false),
            AccelerationTypeHandler = GetComponentTypeHandle<Acceleration>(true),
            KeyboardInputTypeHandler = GetComponentTypeHandle<KeyboardInput>(true),
            DeltaTimeTypeHandler = GetComponentTypeHandle<DeltaTime>(true)
        };

        Dependency = _movePlayerJob.Schedule(_playerMovementSystemQuery);
    }
}