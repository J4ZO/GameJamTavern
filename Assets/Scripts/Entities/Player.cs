using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IHealth
{
    public bool IsDead { get; set; }
    

    [Header("References")]
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject turbo;
    private Animator _animator;
    private Rigidbody2D rb;
    
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
        _animator = GetComponent<Animator>();
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
        health = 0f;
        IsDead = value;
    }
    
    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
    

    public void TakeDamage(float damageAmount)
    {
        _animator.SetTrigger("Hit");
        health -= damageAmount;

        if (health <= 0)
        {
            AnimateDeath();
            Kill(true);
        }
    }
    
    private void AnimateDeath()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        turbo.SetActive(false);
        moveSpeed = 0f;
        _animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
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
