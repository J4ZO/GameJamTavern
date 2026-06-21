using UnityEngine;
using System;

public class GameEvents 
{
   
    // Player
    public static event Action<float> OnPlayerSpeedMovementModified;
    public static event Action<float> OnPlayerSpeedBulletModified;
    public static event Action<bool> OnPlayerWeaponToggled;
    public static event Action<float> OnPlayerGiveHeal;
    public static event Action<float> OnPlayerTakeDamage;
    public static event Action<bool> OnPlayerKilled;
    public static event Action OnPlayerResetValues;
    
    // Boss
    public static event Action<float> OnBossSpeedMovementModified;
    public static event Action<float> OnBossGiveHeal;
    public static event Action<float> OnBossTakeDamage;
    public static event Action<bool> OnBossKilled;
    public static event Action OnBossResetValues;
    
    
    // Enemy
    public static event Action<float> OnEnemySpeedMovementModified;
    public static event Action<float> OnEnemySpeedBulletModified;
    public static event Action OnEnemyResetValues;
    
    // Obstacle
    public static event Action<float> OnObstacleSpeedMovementModified;
    public static event Action OnObstacleResetValues;
    
    
    // Raise Events
    // Player
    public static void RaisePlayerSpeedMovementModified(float speed) 
        => OnPlayerSpeedMovementModified?.Invoke(speed);

    public static void RaisePlayerSpeedBulletModified(float speedBullet) 
        => OnPlayerSpeedBulletModified?.Invoke(speedBullet);

    public static void RaisePlayerWeaponToggled(bool enabled) 
        => OnPlayerWeaponToggled?.Invoke(enabled);

    public static void RaisePlayerHeal(float hp) 
        => OnPlayerGiveHeal?.Invoke(hp);
    
    public static void RaisePlayerTakeDamage(float hp) 
        => OnPlayerTakeDamage?.Invoke(hp);
    
    public static void RaisePlayerKilled(bool isKilled) 
        => OnPlayerKilled?.Invoke(isKilled);
    
    public static void RaisePlayerResetValues() 
        => OnPlayerResetValues?.Invoke();
    
    
    // Boss
    public static void RaiseBossSpeedMovementModified(float speed) 
        => OnBossSpeedMovementModified?.Invoke(speed);
    
    public static void RaiseBossHeal(float hp) 
        => OnBossGiveHeal?.Invoke(hp);
    
    public static void RaiseBossTakeDamage(float hp) 
        => OnBossTakeDamage?.Invoke(hp);
    
    public static void RaiseBossKilled(bool isKilled) 
        => OnBossKilled?.Invoke(isKilled);
    
    public static void RaiseBossResetValues() 
        => OnBossResetValues?.Invoke();
    
    
    // Enemy
    public static void RaiseEnemySpeedMovementModified(float speed) 
        => OnEnemySpeedMovementModified?.Invoke(speed);

    public static void RaiseEnemySpeedBulletModified(float speedBullet) 
        => OnEnemySpeedBulletModified?.Invoke(speedBullet);
    
    public static void RaiseEnemyResetValues() 
        => OnEnemyResetValues?.Invoke();
    
    // Obstacles
    public static void RaiseObstacleSpeedMovementModified(float speed) 
        => OnObstacleSpeedMovementModified?.Invoke(speed);
    
    public static void RaiseObstacleResetValues() 
        => OnObstacleResetValues?.Invoke();
}
