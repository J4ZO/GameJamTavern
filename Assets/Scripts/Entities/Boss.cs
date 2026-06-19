using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    public bool IsDead { get; set; }
    
    [SerializeField] private float health = 1000f;
    [SerializeField] private float damageReceived = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
    
}
