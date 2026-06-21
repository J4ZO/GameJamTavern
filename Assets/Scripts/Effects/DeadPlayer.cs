using UnityEngine;

[CreateAssetMenu(fileName = "DeadPlayerEffect", menuName = "Game/Effects/DeadPlayer")]
public class DeadPlayer : RouletteSO
{
    [SerializeField] private float killValue = 1000f;
    
    public override void Apply(int entity)
    {
        
        GameEvents.RaisePlayerTakeDamage(killValue);
            
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
    }
}
