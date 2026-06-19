using UnityEngine;

public class Obstacles : MonoBehaviour, IDamageable
{
    public bool IsDead { get; set; }
    
    [SerializeField] private float health = 2f;
    [SerializeField] private float damageReceived = 2f;
    
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    public void MoveObstacle(Vector2 speedDirection)
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
}
