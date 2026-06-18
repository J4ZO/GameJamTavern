using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private float speedBullet = 30f;
    private Vector2 _speedDirection;

 

    private void Start()
    {
        _speedDirection = new Vector2(speedBullet, 0);
    }
    

    private void FixedUpdate()
    {
        bullet.Move(_speedDirection);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable entity = other.GetComponent<IDamageable>();
        if (other.GetComponent<IDamageable>() != null)
        {
            gameObject.SetActive(false);
            entity.TakeDamage();
        }
    }
}