using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using UnityEngine;

namespace Root
{
    [GenerateAuthoringComponent]
    public struct MainComponent : IComponentData
    {
        public float Value;
    }
}