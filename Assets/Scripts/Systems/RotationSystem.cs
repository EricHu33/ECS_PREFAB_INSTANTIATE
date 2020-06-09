

using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class RotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float dT = Time.DeltaTime;
        Entities
            .WithAll<RotatableTag>()
            .ForEach((ref Rotation rotation) =>
            {
                rotation.Value = math.mul(rotation.Value, quaternion.AxisAngle(new float3(0, 1, 0), 2f * dT));
            })
            .Schedule();
    }
}
