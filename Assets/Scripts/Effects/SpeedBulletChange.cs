using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBulletEffect", menuName = "Game/Effects/Speed Bullet")]
public class SpeedBulletChange : RouletteSO
{
    [SerializeField] private float newSpeedBullet = 50f;
    [SerializeField] private float newSpeedBulletEnemy = 35f;
    
    
    public override void Apply(int entity)
    {
        switch (entity)
        {
            case 0:
                GameEvents.RaisePlayerSpeedBulletModified(newSpeedBullet);
                break;
            case 1:
                GameEvents.RaiseEnemySpeedBulletModified(newSpeedBulletEnemy);
                break;
            case 2:
                GameEvents.RaisePlayerSpeedBulletModified(newSpeedBullet);
                GameEvents.RaiseEnemySpeedBulletModified(newSpeedBulletEnemy);
                break;
        }
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
        GameEvents.RaiseEnemyResetValues();
    }
}
