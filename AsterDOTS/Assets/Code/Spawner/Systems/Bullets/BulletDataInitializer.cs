using Unity.Entities;

public partial class BulletDataInitializer : SystemBase
{

    private BulletDataInitializeJob _bulletDataInitializeJob;

    public partial struct BulletDataInitializeJob : IJobEntity
    {
        public Entity Prefab;

        public int Damage;
        public float TravelSpeed;
        public float LifeDuration;

        public void Execute(ref BulletSpawnData bulletSpawnData)
        {
            bulletSpawnData.Damage = Damage;
            bulletSpawnData.TravelSpeed = TravelSpeed;
            bulletSpawnData.LifeDuration = LifeDuration;
        }
    }

    protected override void OnCreate()
    {
        _bulletDataInitializeJob = new BulletDataInitializeJob();
    }

    protected override void OnUpdate()
    {
        _bulletDataInitializeJob.LifeDuration = 5;
        _bulletDataInitializeJob.Damage = 10;
        _bulletDataInitializeJob.TravelSpeed = 7;

        _bulletDataInitializeJob.Run();
    }
}