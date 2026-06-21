using UnityEngine;

[CreateAssetMenu(fileName = "ToggleWeaponEffect", menuName = "Game/Effects/Toggle")]
public class ToggleWeapon : RouletteSO
{
    public override void Apply(int entity)
    {
        GameEvents.RaisePlayerWeaponToggled(false);
    }

    public override void Remove()
    {
        GameEvents.RaisePlayerResetValues();
    }
}
