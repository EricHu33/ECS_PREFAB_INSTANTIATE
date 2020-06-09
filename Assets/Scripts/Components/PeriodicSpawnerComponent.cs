using Unity.Entities;

public struct PeriodicSpawnerComponent : IComponentData
{
    public Entity Prefab;
    public float SecondsBetweenSpawns;
    public float SecondsToNextSpawn;
}
