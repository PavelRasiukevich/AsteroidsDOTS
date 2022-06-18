using Unity.Entities;
using Unity.Transforms;

public partial class PlayerMovement : SystemBase
{
    private EntityQuery _playerMovementSystemQuery;
    private MovePlayerJob _movePlayerJob;
    private EntityQueryDesc _queryDescription;

    protected override void OnCreate()
    {
        _queryDescription = new EntityQueryDesc
        {
            All = new ComponentType[] { typeof(PlayerTag) }
        };
    }

    protected override void OnUpdate()
    {
        _playerMovementSystemQuery = GetEntityQuery(_queryDescription);

        _movePlayerJob = new MovePlayerJob
        {
            TranslationTypeHandler = GetComponentTypeHandle<Translation>(false),
            AccelerationTypeHandler = GetComponentTypeHandle<Acceleration>(true),
            KeyboardInputTypeHandler = GetComponentTypeHandle<KeyboardInput>(true),
            DeltaTimeTypeHandler = GetComponentTypeHandle<DeltaTime>(true)
        };

        _movePlayerJob.Run(_playerMovementSystemQuery);
    }
}