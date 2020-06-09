using System;
using Unity.Entities;

public struct SpawnerListComponent : IBufferElementData
{
    public Entity Prefab;
}