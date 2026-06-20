using UnityEngine;

public interface IDamageable
{
    public void  TakeDamage(float damageAmount);
    public void SpeedShoot(float speedShoot);
    public void SpeedMovement(float speedMovement);
    public void ResetValues();
    
}
