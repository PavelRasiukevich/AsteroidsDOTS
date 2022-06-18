using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct MovePlayerJob : IJobEntityBatch
{
    public ComponentTypeHandle<Translation> TranslationTypeHandler;

    [ReadOnly] public ComponentTypeHandle<Acceleration> AccelerationTypeHandler;
    [ReadOnly] public ComponentTypeHandle<KeyboardInput> KeyboardInputTypeHandler;
    [ReadOnly] public ComponentTypeHandle<DeltaTime> DeltaTimeTypeHandler;

    public void Execute(ArchetypeChunk batchInChunk, int batchIndex)
    {
        var translationArray = batchInChunk.GetNativeArray(TranslationTypeHandler);

        var accelerationArray = batchInChunk.GetNativeArray(AccelerationTypeHandler);
        var keyboardInputArray = batchInChunk.GetNativeArray(KeyboardInputTypeHandler);
        var deltaTimeArray = batchInChunk.GetNativeArray(DeltaTimeTypeHandler);

        for (var i = 0; i < batchInChunk.Count; i++)
        {
            var translation = translationArray[i];

            var acceleration = accelerationArray[i];
            var input = keyboardInputArray[i];
            var deltaTime = deltaTimeArray[i];

            var movement = new float3
            {
                x = acceleration.MoveAccelerationValue * input.MoveValue * deltaTime.Value,
            };

            translation.Value += movement;
            translationArray[i] = translation;
        }
    }
}