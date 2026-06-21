using UnityEngine;

[CreateAssetMenu(fileName = "FreezeEffect", menuName = "Game/Effects/Freeze")]
public class Freeze : RouletteSO
{
    [SerializeField] private float speedFreeze = 0f;
    
    
    public override void Apply(int entity)
    {
        switch (entity)
        {
            case 0:
                GameEvents.RaisePlayerSpeedMovementModified(speedFreeze);
                break;
            case 1:
                GameEvents.RaiseEnemySpeedMovementModified(speedFreeze);
                GameEvents.RaiseBossSpeedMovementModified(speedFreeze);
                GameEvents.RaiseObstacleSpeedMovementModified(speedFreeze);
                break;
            case 2:
                GameEvents.RaisePlayerSpeedMovementModified(speedFreeze);
                GameEvents.RaiseEnemySpeedMovementModified(speedFreeze);
                GameEvents.RaiseBossSpeedMovementModified(speedFreeze);
                GameEvents.RaiseObstacleSpeedMovementModified(speedFreeze);
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
