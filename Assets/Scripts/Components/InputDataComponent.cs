using System;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct InputDataComponent : IComponentData
{
    public bool Up;
    public bool Left;
    public bool Right;
}