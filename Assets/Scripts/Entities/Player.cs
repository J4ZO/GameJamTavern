using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealth
{
    public bool IsDead { get; set; }
    private Rigidbody2D rb;

    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    
    
    [Header("Variables")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float speedBulletX = 30f;
    [SerializeField] private float moveSpeed = 10;
    
    [Header("Initial Values")] 
    private float _initialSpeedPlayer;
    private float _initialSpeedBullet;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        _initialSpeedPlayer = moveSpeed;
        _initialSpeedBullet =  speedBulletX;
    }
    
    // Movement
    public void SpeedMovement(float speedMovement)
    {
        moveSpeed = speedMovement;
    }

    public void Move(Vector2 dir)
    {
        rb.MovePosition(rb.position + dir * (moveSpeed * Time.fixedDeltaTime));
    }
    
    // Health
    public void Heal(float hp)
    {
        health += hp;
        if(health > maxHealth ) health = maxHealth;
    }
    
    public void Kill()
    {
        IsDead = true;
    }
    

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    
    
    
    // Shoot
    public void SpeedShoot(float speedShoot)
    {
        speedBulletX = speedShoot;
    }

    public void Shoot()
    {
        Vector2 speedFinal = new Vector2(speedBulletX,0f);
        ShootingSystem.Instance.CreateBullet(bulletSpawn,speedFinal,"Enemy");
    }
    
    // Reset Values
    public void ResetValues()
    {
        moveSpeed = _initialSpeedPlayer;
        speedBulletX = _initialSpeedBullet;
    }

    
}
