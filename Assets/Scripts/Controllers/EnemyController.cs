using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy _enemy;
    [SerializeField] private float speedEnemy;
    private Vector2 _speedDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _speedDirection = new Vector2(-speedEnemy, 0f);
    }

    private void FixedUpdate()
    {
        _enemy.MoveEnemy(_speedDirection);
            
    }
}
