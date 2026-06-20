using UnityEngine;

public interface IHealth
{
    public void  Heal(float healAmount);
    public void Kill();
    public bool IsDead { get; set; }
}
