
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

public class InputSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities
            .ForEach((ref InputDataComponent inputData) =>
            {
                inputData.Up = Input.GetKey(KeyCode.UpArrow);
                inputData.Left = Input.GetKey(KeyCode.LeftArrow);
                inputData.Right = Input.GetKey(KeyCode.RightArrow);
            }).Run();

        return default;
    }
}
