using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    
    [Header("Variables")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 6f;
    [SerializeField] private float bulletDelay = 2f ;
    [SerializeField] private float speedBulletX = 20f;
    [SerializeField] private float speedEnemy = 5f;
    private Vector2 _speedDirection;
    private Rigidbody2D _rb;

    [Header("Initial Values")] 
    private float _initialSpeedEnemy;
    private float _initialSpeedBullet;
    
    
    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();   
        health =  maxHealth;

        _initialSpeedEnemy = speedEnemy;
        _initialSpeedBullet =  speedBulletX;
    }
    
    // Subscribe and Unsubscribe Events
    private void OnEnable()
    {
        GameEvents.OnEnemySpeedMovementModified += SpeedMovement;
        GameEvents.OnEnemySpeedBulletModified += SpeedShoot;
        GameEvents.OnEnemyResetValues += ResetValues;
    }

    private void OnDisable()
    {
        GameEvents.OnEnemySpeedMovementModified -= SpeedMovement;
        GameEvents.OnEnemySpeedBulletModified -= SpeedShoot;
        GameEvents.OnEnemyResetValues -= ResetValues;
    }


    // Movement

    public void SetMovement()
    {
        _speedDirection = new Vector2(-speedEnemy, 0f);
    }

    public void MoveEnemy()
    {
        _rb.MovePosition(_rb.position + _speedDirection * Time.fixedDeltaTime);
    }
    
    public void SpeedMovement(float speedMovement)
    {
        speedEnemy =  speedMovement;
    }
    
    
    
    // Health
    

    public void TakeDamage(float damageReceived)
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
    
    
    
    // Shoot
    public void SpeedShoot(float speedShoot)
    {
        speedBulletX = -speedShoot;
    }
   
    public void ShootEnemy()
    {
       
        StartCoroutine(BulletLoop());
        
    }

    public void StopShootEnemy()
    {
        StopCoroutine(BulletLoop());
    }
    
    private IEnumerator BulletLoop()
    {
        yield return new WaitForEndOfFrame();
        while (true)
        {
            Vector2 speedFinal = new Vector2(-speedBulletX,0f);
            ShootingSystem.Instance.CreateBullet(bulletSpawn,speedFinal, "Player");
            yield return new WaitForSeconds(bulletDelay);
        }
    }
    
    
    
    // Reset Values
    public void ResetValues()
    {
        speedEnemy = _initialSpeedEnemy;
        speedBulletX = _initialSpeedBullet;
    }
   
}
