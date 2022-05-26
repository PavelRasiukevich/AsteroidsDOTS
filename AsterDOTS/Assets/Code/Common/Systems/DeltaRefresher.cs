using Unity.Entities;

public partial class DeltaRefresher : SystemBase
{
    private EntityQuery _query;
    private RefreshDeltaTimeJob _refreshDeltaTimeJob;

    protected override void OnCreate()
    {
        _query = GetEntityQuery(typeof(DeltaTime));
        _refreshDeltaTimeJob = new RefreshDeltaTimeJob();
    }

    protected override void OnUpdate()
    {
        _refreshDeltaTimeJob.Delta = Time.DeltaTime;
        _refreshDeltaTimeJob.Run(_query);
    }
}