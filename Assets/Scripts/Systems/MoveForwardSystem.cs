

using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class MoveForwardSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float dT = Time.DeltaTime;
        Entities
            .WithAll<MoveFowardComponent>()
            .ForEach((ref Translation translation, in Rotation rotation, in SpeedComponent speedComponent) =>
            {
                var direction = math.mul(rotation.Value, new float3(0f, 0f, 1f));
                translation.Value += direction * dT * speedComponent.Value;
            })
            .Schedule();
    }
}

public class MoveDirectionSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float dT = Time.DeltaTime;
        Entities
            .ForEach((ref Translation translation, in SpeedComponent speedComponent, in MoveDirectionComponent moveDirectionComponent) =>
            {
                var direction = moveDirectionComponent.Value;
                translation.Value += direction * dT * speedComponent.Value;
            })
            .Schedule();
    }
}

