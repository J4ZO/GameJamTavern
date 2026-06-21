using UnityEngine;

[CreateAssetMenu(fileName = "MaxHealEffect", menuName = "Game/Effects/MaxHeal")]
public class MaxHealth : RouletteSO
{
    [SerializeField] private float maxHeal = 1000f;
    
    public override void Apply(int entity)
    {
        switch (entity)
        {
            case 0:
                GameEvents.RaisePlayerHeal(maxHeal);
                break;
            case 1:
                GameEvents.RaiseBossHeal(maxHeal);
                break;
            case 2:
                GameEvents.RaisePlayerHeal(maxHeal);
                GameEvents.RaiseBossHeal(maxHeal);
                break;
        }
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
        GameEvents.RaiseBossResetValues();
    }
}
