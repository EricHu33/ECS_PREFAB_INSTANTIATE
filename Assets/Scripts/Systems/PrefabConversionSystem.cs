using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PrefabConversionSystem : GameObjectConversionSystem
{
    protected override void OnUpdate()
    {
        var spawners = GetEntityQuery(typeof(PrefabAuthoring)).ToComponentArray<PrefabAuthoring>();
        for (int i = 0; i < spawners.Length; i++)
        {
            DstEntityManager.AddComponentData(GetPrimaryEntity(spawners[i]), new PeriodicSpawnerComponent
            {
                Prefab = GetPrimaryEntity(spawners[i].Prefab),
                SecondsBetweenSpawns = 0.1f,
                SecondsToNextSpawn = 0
            });
        }
    }
}