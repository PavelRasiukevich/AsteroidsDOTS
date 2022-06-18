using Unity.Entities;

public partial struct ListenToInputJob : IJobEntity 
{
    public float MoveValue;
    public float RotationValue;
    public float AttackValue;

    public void Execute(ref KeyboardInput input)
    {
        input.MoveValue = MoveValue;
    }
}