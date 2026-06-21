using UnityEngine;

[CreateAssetMenu(fileName = "DeadBossEffect", menuName = "Game/Effects/DeadBoss")]
public class DeadBoss : RouletteSO
{
    [SerializeField] private float killValue = 10000f;
    
    public override void Apply(int entity)
    {
        GameEvents.RaiseBossTakeDamage(killValue);
       
    }

    public override void Remove()
    {
        GameEvents.RaiseBossResetValues();
    }
}
