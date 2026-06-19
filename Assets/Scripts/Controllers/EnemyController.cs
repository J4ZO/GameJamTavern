using System;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    private Enemy _enemy;
    
    [Header("Variables")]
    [SerializeField] private float speedEnemy;
    private Vector2 _speedDirection;
    [SerializeField] private float bulletDelay = 2f ;
    
    [SerializeField] private float speedBulletX = -20f;
    
    
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        
    }

    private void OnEnable()
    {
        
        StartCoroutine(BulletLoop());
    }

    private void OnDisable()
    {
        StopCoroutine(BulletLoop());
    }


    void Update()
    {
        _speedDirection = new Vector2(-speedEnemy, 0f);
    }

    private void FixedUpdate()
    {
        _enemy.MoveEnemy(_speedDirection);
            
    }

    IEnumerator BulletLoop()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("Shooting exist: " + (ShootingSystem.Instance != null));
        while (true)
        {
            Vector2 speedFinal = new Vector2(speedBulletX,0f);
            ShootingSystem.Instance.CreateBullet(bulletSpawn,speedFinal);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
}
