using UnityEngine;

public interface IDamageable
{
    public void  TakeDamage();
    public bool IsDead { get; set; }
}
