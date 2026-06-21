using UnityEngine;

[CreateAssetMenu(fileName = "damageEffect", menuName = "Game/Effects/Damage")]
public class ReduceHealth : RouletteSO
{
    [SerializeField] private float damagePlayer = 30f;
    [SerializeField] private float damageBoss = 100f;
    
    public override void Apply(int entity)
    {
        switch (entity)
        {
            case 0:
                GameEvents.RaisePlayerTakeDamage(damagePlayer);
                break;
            case 1:
                GameEvents.RaiseBossTakeDamage(damageBoss);
                break;
            case 2:
                GameEvents.RaisePlayerTakeDamage(damagePlayer);
                GameEvents.RaiseBossTakeDamage(damageBoss);
                break;
        }
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
        GameEvents.RaiseBossResetValues();
    }
}
