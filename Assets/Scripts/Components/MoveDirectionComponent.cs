using System;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

[GenerateAuthoringComponent]
public struct MoveDirectionComponent : IComponentData
{
    public float3 Value;
}