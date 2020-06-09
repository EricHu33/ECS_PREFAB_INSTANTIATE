using System;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpeedComponent : IComponentData
{
    public float Value;
}