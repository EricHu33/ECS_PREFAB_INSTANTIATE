
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class PeriodicSpawnSystem : ComponentSystem
{
    private Unity.Mathematics.Random random;
    protected override void OnCreate()
    {
        random = new Unity.Mathematics.Random(1024);
    }


    protected override void OnUpdate()
    {
        Entities
            .ForEach((ref PeriodicSpawnerComponent spawner, ref Translation translation, ref Rotation rotation) =>
            {
                spawner.SecondsToNextSpawn -= Time.DeltaTime;
                if (spawner.SecondsToNextSpawn < 0)
                {
                    var prefabs = EntityManager.GetBuffer<SpawnerListComponent>(spawner.Prefab);
                    spawner.SecondsToNextSpawn = spawner.SecondsBetweenSpawns;
                    var instance = EntityManager.Instantiate(prefabs[random.NextInt(0, prefabs.Length)].Prefab);
                    EntityManager.SetComponentData(instance, translation);
                    EntityManager.SetComponentData(instance, rotation);
                    if (EntityManager.HasComponent<MoveDirectionComponent>(instance))
                    {
                        EntityManager.SetComponentData(instance, new MoveDirectionComponent()
                        {
                            Value = math.mul(rotation.Value, new float3(0f, 0f, 1f))
                        });
                    }
                }
            });
    }
}
