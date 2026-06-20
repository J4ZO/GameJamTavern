using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    public bool IsDead { get; set; }
    
    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    
    [Header("Variables")]
    [SerializeField] private float health = 6f;
    [SerializeField] private float bulletDelay = 2f ;
    [SerializeField] private float speedBulletX = -20f;
    
    
    private Rigidbody2D _rb;

    
    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();   
    }
    

    public void MoveEnemy(Vector2 speedDirection)
    {
        _rb.MovePosition(_rb.position + speedDirection * Time.fixedDeltaTime);
    }
    
    public void TakeDamage(int damageReceived)
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
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
        Debug.Log("Shooting exist: " + (ShootingSystem.Instance != null));
        while (true)
        {
            Vector2 speedFinal = new Vector2(speedBulletX,0f);
            ShootingSystem.Instance.CreateBullet(bulletSpawn,speedFinal);
            yield return new WaitForSeconds(bulletDelay);
        }
    }
   
}
