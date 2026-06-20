using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public bool IsDead { get; set; }
    private Rigidbody2D rb;

    [Header("Variables")]
    [SerializeField] private float health;
    [SerializeField] private float maxHealth = 100f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }


    public void Move(Vector2 dir, float speed)
    {
        rb.MovePosition(rb.position + dir * (speed * Time.fixedDeltaTime));
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    
}
