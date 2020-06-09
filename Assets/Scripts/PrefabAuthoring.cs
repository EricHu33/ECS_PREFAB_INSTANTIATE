
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PrefabAuthoring : MonoBehaviour, IDeclareReferencedPrefabs
{
    public MutilPrefabsAuthoring Prefab;
    public void DeclareReferencedPrefabs(List<GameObject> referencedPrefabs)
        => referencedPrefabs.Add(Prefab.gameObject);
}