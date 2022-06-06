using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// ������ ���� 
/// ������ ����� �������� ����� 
/// �������� �� ������ 
/// </summary>
public partial class SpecifyEnemyType : SystemBase
{
    private Entity _enemySpawnDataEntity;

    protected override void OnStartRunning()
    {
        _enemySpawnDataEntity = GetSingletonEntity<EnemySpawnData>();
    }

    protected override void OnUpdate()
    {
        Entities.ForEach((in GlobalTime global) =>
        {

        }).Run();
    }
}
