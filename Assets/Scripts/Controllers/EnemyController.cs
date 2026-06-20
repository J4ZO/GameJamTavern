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
    
}
