using Unity.Entities;

public partial struct ListenToInputJob : IJobEntity
{
    public float m_Value;
    public float r_Value;

    public void Execute(ref KeyboardInput input)
    {
        input.MoveValue = m_Value;
        input.RotationValue = r_Value;
    }
}