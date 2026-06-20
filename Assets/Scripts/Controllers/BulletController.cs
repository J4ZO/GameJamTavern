using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    

    private void FixedUpdate()
    {
        bullet.Move();
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable entity = other.GetComponent<IDamageable>();
        if (other.GetComponent<IDamageable>() != null)
        {
            gameObject.SetActive(false);
            entity.TakeDamage(2);
        }
    }
}