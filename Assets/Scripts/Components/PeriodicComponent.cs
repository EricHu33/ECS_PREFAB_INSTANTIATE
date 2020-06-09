using System;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct PeriodicComponent : IComponentData
{
    public float Period;
    public float RemainTime;
}