using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using UnityEngine;

public class MutilPrefabsAuthoring : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    [SerializeField]
    public GameObject[] Prefabs;
    [SerializeField]
    public PrefabsSettings PrefabsSetting;

    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
    {
        referencedPrefabs.AddRange(Prefabs);
        referencedPrefabs.AddRange(PrefabsSetting.Models.Select(x => x.Prefab));
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
        foreach (var prefab in PrefabsSetting.Models.Select(x => x.Prefab))
        {
            buffer.Add(new SpawnerListComponent
            {
                Prefab = conversionSystem.GetPrimaryEntity(prefab),
            });
        }
    }
}

