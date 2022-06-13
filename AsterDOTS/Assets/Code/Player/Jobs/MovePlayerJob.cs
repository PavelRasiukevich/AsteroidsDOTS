using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct MovePlayerJob : IJobEntityBatch
{
    public ComponentTypeHandle<Translation> TranslationTypeHandler; 
    public ComponentTypeHandle<Rotation> RotationTypeHandler;

    [ReadOnly] public ComponentTypeHandle<Acceleration> AccelerationTypeHandler;
    [ReadOnly] public ComponentTypeHandle<KeyboardInput> KeyboardInputTypeHandler;
    [ReadOnly] public ComponentTypeHandle<DeltaTime> DeltaTimeTypeHandler;

    public void Execute(ArchetypeChunk batchInChunk, int batchIndex)
    {
        var translationArray = batchInChunk.GetNativeArray(TranslationTypeHandler);
        var rotationArray = batchInChunk.GetNativeArray(RotationTypeHandler);

        var accelerationArray = batchInChunk.GetNativeArray(AccelerationTypeHandler);
        var keyboardInputArray = batchInChunk.GetNativeArray(KeyboardInputTypeHandler);
        var deltaTimeArray = batchInChunk.GetNativeArray(DeltaTimeTypeHandler);

        for (var i = 0; i < batchInChunk.Count; i++)
        {
            var translation = translationArray[i];
            var rotation = rotationArray[i];

            var acceleration = accelerationArray[i];
            var input = keyboardInputArray[i];
            var deltaTime = deltaTimeArray[i];


            rotation.Value = math.mul(rotation.Value,
                quaternion.RotateY(acceleration.RotateAccelerationValue * input.RotationValue * deltaTime.Value));

            var movement = new float3
            {
                x = 0,
                y = 0,
                z = acceleration.MoveAccelerationValue * input.MoveValue * deltaTime.Value,
            };

            var direction = math.mul(rotation.Value, movement);

            translation.Value += direction;

            rotationArray[i] = rotation;
            translationArray[i] = translation;
        }
    }
}