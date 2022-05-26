using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Root
{
    [DisableAutoCreation]
    public partial class TestSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            Entities.WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
                .ForEach((ref Translation c0) => { c0.Value.z += 0.1f; }).Run();
        }
    }

    public partial class TestSystem2 : SystemBase
    {
        protected override void OnUpdate()
        {
            /*Entities
                .ForEach((ref Translation c0, in SeconComp c1) => { c0.Value.z += c1.Value; }).Run();*/
        }
    }
}