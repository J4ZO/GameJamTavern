using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public bool IsDead { get; set; }
    
    [Header("Variables")]
    [SerializeField] private float health = 6f;
    [SerializeField] private float damageReceived = 2f;
    
    
    private Rigidbody2D _rb;

    
    void Start()
    { 
        _rb = GetComponent<Rigidbody2D>();   
    }
    

    public void MoveEnemy(Vector2 speedDirection)
    {
        _rb.MovePosition(_rb.position + speedDirection * Time.fixedDeltaTime);
    }
    
    public void TakeDamage()
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void ShootEnemy()
    {
        
    }
   
}
