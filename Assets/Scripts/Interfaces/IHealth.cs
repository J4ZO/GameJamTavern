using UnityEngine;

public interface IHealth
{
    public void  Heal(float healAmount);
    public void Kill(bool value);
    public bool IsDead { get; set; }
}
