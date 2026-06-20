using UnityEngine;

public class Obstacles : MonoBehaviour, IDamageable
{
    public void SpeedShoot(float speedShoot) { }
    
    [Header("Variables")]
    [SerializeField] private float health = 2f;
    [SerializeField] private float speedObstacle = 3f;
    private Vector2 _speedDirection;
    private Rigidbody2D _rb;
    
    [Header("Initial Values")] 
    private float _initialSpeedObstacle;
    
    
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _initialSpeedObstacle = speedObstacle;
    }

    public void SetSpeedDirection()
    {
        _speedDirection = new Vector2(-speedObstacle, 0f);
    }
    
    public void MoveObstacle()
    {
        _rb.MovePosition(_rb.position + _speedDirection * Time.fixedDeltaTime);
    }
    
    public void SpeedMovement(float speedMovement)
    {
        speedObstacle = speedMovement;
    }
   
    
    public void TakeDamage(float damageReceived)
    {
        health -= damageReceived;

        if (health <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
    
    // Reset Values
    public void ResetValues()
    {
        speedObstacle = _initialSpeedObstacle;
    }
}
