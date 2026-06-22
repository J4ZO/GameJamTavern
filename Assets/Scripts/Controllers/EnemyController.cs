using System;

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    private Enemy _enemy;
    
    
    
    
    void Awake()
    {
        _enemy = GetComponent<Enemy>();
        
    }

    private void OnEnable()
    {
        _enemy.ShootEnemy();
    }

    private void OnDisable()
    {
        _enemy.StopShootEnemy();
    }


    void Update()
    {
        _enemy.SetMovement();
    }

    private void FixedUpdate()
    {
        _enemy.MoveEnemy();
            
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var entity = other.GetComponent<IDamageable>();
        if (other.CompareTag("Player") && entity != null)
        {
            _enemy.AnimateDeath();
            entity.TakeDamage(1);
        } else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
}
