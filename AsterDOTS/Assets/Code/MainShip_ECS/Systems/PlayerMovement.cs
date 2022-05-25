using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial class PlayerMovement : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, in Rotation rot, in MoveAcceleration acceleration,
            in KeyboardInput input) =>
        {
            var movement = new float3
            {
                x = 0,
                y = 0,
                z = acceleration.Value * input.MoveValue,
            };

            var direction = math.mul(rot.Value, movement);
            
            translation.Value += direction;

        }).Run();
    }
}

public partial class PlayerRotation : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rotation, in RotationAcceleration acceleration,
            in KeyboardInput input) =>
        {
            rotation.Value = math.mul(rotation.Value,
                quaternion.RotateY(acceleration.Value * input.RotationValue * 0.1f));
        }).Run();
    }
}