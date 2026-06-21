using UnityEngine;

[CreateAssetMenu(fileName = "HealEffect", menuName = "Game/Effects/Heal")]
public class GiveHealth : RouletteSO
{
    [SerializeField] private float healPlayer = 20f;
    [SerializeField] private float healBoss = 50f;
    
    public override void Apply(int entity)
    {
        switch (entity)
        {
            case 0:
                GameEvents.RaisePlayerHeal(healPlayer);
                break;
            case 1:
                GameEvents.RaiseBossHeal(healBoss);
                break;
            case 2:
                GameEvents.RaisePlayerHeal(healPlayer);
                GameEvents.RaiseBossHeal(healBoss);
                break;
        }
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
        GameEvents.RaiseBossResetValues();
    }
}
