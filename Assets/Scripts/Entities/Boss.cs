using UnityEngine;

public class Boss : MonoBehaviour, IDamageable, IHealth
{
    public bool IsDead { get; set; }
    public void SpeedShoot(float speedShoot) { }
    private Rigidbody2D _rb;
    
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 600f;
    [SerializeField] private float speedBoss;
    private Vector2 _speedDirection;
    
    [Header("Initial Values")] 
    private float _initialSpeedBoss;
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        health =  maxHealth;
        _initialSpeedBoss =  speedBoss;
    }

    // Health
    public void Heal(float hp)
    {
        health += hp;
        if(health > maxHealth ) health = maxHealth;
    }

    public void TakeDamage(float damageReceived)
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void Kill()
    {
        IsDead = true;
    }

    // Movement
    public void SetSpeedDirection()
    {
       _speedDirection = new Vector2(-speedBoss, 0f);
    }
    
    
    public void MoveBoss()
    {
        _rb.MovePosition(_rb.position + _speedDirection * Time.fixedDeltaTime);
    }
    
    public void SpeedMovement(float speedMovement)
    {
        speedBoss = speedMovement;
    }
    
    // Reset Values
    public void ResetValues()
    {
        speedBoss = _initialSpeedBoss;
    }
    
}
