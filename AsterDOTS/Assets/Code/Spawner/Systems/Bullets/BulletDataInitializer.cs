using System;
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
        _bulletDataInitializeJob.LifeDuration = new Random().Next(1, 4);
        _bulletDataInitializeJob.Damage = new Random().Next(1, 25);
        _bulletDataInitializeJob.TravelSpeed = 10;

        _bulletDataInitializeJob.Run();
    }
}