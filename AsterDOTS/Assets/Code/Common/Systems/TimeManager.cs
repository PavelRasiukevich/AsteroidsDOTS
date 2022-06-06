using Unity.Entities;
using UnityEngine;

public partial class TimeManager : SystemBase
{
    protected override void OnUpdate()
    {
        var time = (int)Time.ElapsedTime;

        Entities.ForEach((ref GlobalTime global) =>
        {
            global.Time = time;
        }).Run();
    }
}
