using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PrefabModel
{
    public GameObject Prefab;
}

[CreateAssetMenu(menuName = "Sample/PrefabsSetting")]
public class PrefabsSettings : ScriptableObject
{
    [SerializeField]
    public List<PrefabModel> Models;
}