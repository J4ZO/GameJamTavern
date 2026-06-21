using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealth
{
    public bool IsDead { get; set; }
    private Rigidbody2D rb;

    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    
    
    [Header("Variables")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 60f;
    [SerializeField] private float speedBulletX = 30f;
    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private bool canShoot;
    
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
    
    // Subscribe and Unsubscribe Events
    private void OnEnable()
    {
        GameEvents.OnPlayerSpeedMovementModified += SpeedMovement;
        GameEvents.OnPlayerSpeedBulletModified += SpeedShoot;
        GameEvents.OnPlayerWeaponToggled += ToggleWeapon;
        GameEvents.OnPlayerGiveHeal += Heal;
        GameEvents.OnPlayerTakeDamage += TakeDamage;
        GameEvents.OnPlayerKilled += Kill;
        GameEvents.OnPlayerResetValues += ResetValues;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerSpeedMovementModified -= SpeedMovement;
        GameEvents.OnPlayerSpeedBulletModified -= SpeedShoot;
        GameEvents.OnPlayerWeaponToggled -= ToggleWeapon;
        GameEvents.OnPlayerGiveHeal -= Heal;
        GameEvents.OnPlayerTakeDamage -= TakeDamage;
        GameEvents.OnPlayerKilled -= Kill;
        GameEvents.OnPlayerResetValues -= ResetValues;
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
    
    public void Kill(bool value)
    {
        IsDead = value;
    }
    

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
            Kill(true);
        }
    }
    
    
    
    // Shoot
    public void SpeedShoot(float speedShoot)
    {
        speedBulletX = speedShoot;
    }

    public void Shoot()
    {
        if (canShoot)
        {
            Vector2 speedFinal = new Vector2(speedBulletX,0f);
            ShootingSystem.Instance.CreateBullet(bulletSpawn,speedFinal,"Enemy");
        }  
    }


    private void ToggleWeapon(bool value)
    {
        canShoot = value;
    }
    
    // Reset Values
    public void ResetValues()
    {
        moveSpeed = _initialSpeedPlayer;
        speedBulletX = _initialSpeedBullet;
        canShoot = true;
    }

    
}
