using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using UnityEngine;

public class PeriodicMutilPrefabsAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    [SerializeField]
    public GameObject[] Prefabs;

    public float SpawnPeriod;

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.AddRange(Prefabs);
    }

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var buffer = dstManager.AddBuffer<SpawnerListComponent>(entity);
        foreach (var prefab in Prefabs)
        {
            buffer.Add(new SpawnerListComponent
            {
                Prefab = conversionSystem.GetPrimaryEntity(prefab),
            });
        }
        dstManager.AddComponentData<PeriodicSpawnerComponent>(entity, new PeriodicSpawnerComponent()
        {
            Prefab = entity,
            SecondsBetweenSpawns = SpawnPeriod,
            SecondsToNextSpawn = 0,
        });
    }
}

