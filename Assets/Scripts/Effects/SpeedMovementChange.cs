using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedMovementEffect", menuName = "Game/Effects/Speed Movement")]
public class SpeedMovementChange : RouletteSO
{
    [SerializeField] private float maxSpeedPlayer = 15f;
    [SerializeField] private float maxSpeedEnemy = 10f;
    [SerializeField] private float maxSpeedBoss = 0.3f;
    [SerializeField] private float maxSpeedObstacle = 6f;
    
    
    public override void Apply(int entity)
    {
        switch (entity)
        {
            case 0:
                GameEvents.RaisePlayerSpeedMovementModified(maxSpeedPlayer);
                break;
            case 1:
                GameEvents.RaiseEnemySpeedMovementModified(maxSpeedEnemy);
                GameEvents.RaiseBossSpeedMovementModified(maxSpeedBoss);
                GameEvents.RaiseObstacleSpeedMovementModified(maxSpeedObstacle);
                break;
            case 2:
                GameEvents.RaisePlayerSpeedMovementModified(maxSpeedPlayer);
                GameEvents.RaiseEnemySpeedMovementModified(maxSpeedEnemy);
                GameEvents.RaiseBossSpeedMovementModified(maxSpeedBoss);
                GameEvents.RaiseObstacleSpeedMovementModified(maxSpeedObstacle);
                break;
        }
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
        GameEvents.RaiseEnemyResetValues();
        GameEvents.RaiseBossResetValues();
        GameEvents.RaiseObstacleResetValues();
    }
}
