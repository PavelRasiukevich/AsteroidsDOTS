using Unity.Entities;
using UnityEngine.InputSystem;

/// <summary>
/// Просто тест 
/// систма будет работать иначе 
/// независя от инпута
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
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            EntityManager.AddComponent<TankTag>(_enemySpawnDataEntity);

            if (EntityManager.HasComponent<RangerTag>(_enemySpawnDataEntity))
                EntityManager.RemoveComponent<RangerTag>(_enemySpawnDataEntity);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            EntityManager.AddComponent<RangerTag>(_enemySpawnDataEntity);

            if (EntityManager.HasComponent<TankTag>(_enemySpawnDataEntity))
                EntityManager.RemoveComponent<TankTag>(_enemySpawnDataEntity);
        }
    }
}
