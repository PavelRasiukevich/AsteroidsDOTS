using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial class TSISystem : SystemBase
{
    protected override void OnStartRunning()
    {
		Entities
			.WithAll<Spd>()
			.ForEach((Entity e, int entityInQueryIndex) =>
			{
				var c = EntityManager.GetComponentCount(e);
				Debug.Log(c);

			}).WithoutBurst().Run();
	}

    protected override void OnUpdate()
	{
		
	}
}