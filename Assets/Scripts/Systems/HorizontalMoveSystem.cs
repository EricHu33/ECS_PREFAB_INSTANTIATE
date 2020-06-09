

using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class HorizontalMoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;
        Entities
            .WithAll<HorizontalMoveComponent>()
            .ForEach((ref Translation translation, in InputDataComponent inputDataComponent, in SpeedComponent speed) =>
            {
                var left = inputDataComponent.Left ? 1 : 0;
                var right = inputDataComponent.Right ? 1 : 0;
                translation.Value += left * new float3(-1, 0, 0) * deltaTime * speed.Value;
                translation.Value += right * new float3(1, 0, 0) * deltaTime * speed.Value;
            })
            .Schedule();
    }
}
