using Unity.Entities;

public partial struct RefreshDeltaTimeJob : IJobEntity
{
    public float Delta;

    public void Execute(ref DeltaTime time)
    {
        time.Value = Delta;
    }
}