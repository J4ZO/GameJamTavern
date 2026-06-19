using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    public bool IsDead { get; set; }
    private Rigidbody2D _rb;
    
    [SerializeField] private float health = 1000f;
    [SerializeField] private float damageReceived = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
    
    public void MoveBoss(Vector2 speedDirection)
    {
        _rb.MovePosition(_rb.position + speedDirection * Time.fixedDeltaTime);
    }
    
}
