using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Root
{
    [WriteGroup(typeof(Translation))]
    [GenerateAuthoringComponent]
    public struct SeconComp : IComponentData
    {
        public float Value;
    }
}