using System;

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    private Enemy _enemy;
    
    [Header("Variables")]
    [SerializeField] private float speedEnemy;
    private Vector2 _speedDirection;
    
    
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
        _speedDirection = new Vector2(-speedEnemy, 0f);
    }

    private void FixedUpdate()
    {
        _enemy.MoveEnemy(_speedDirection);
            
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var entity = other.GetComponent<IDamageable>();
        if (other.CompareTag("Player") && entity != null)
        {
            gameObject.SetActive(false);
            entity.TakeDamage(1);
        } else if (other.CompareTag("Wall"))
        {
            Debug.Log("Touched wall");
            Destroy(gameObject);
        }
    }
    
}
