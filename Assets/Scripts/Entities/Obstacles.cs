using System.Collections;
using UnityEngine;

public class Obstacles : MonoBehaviour, IDamageable
{
    public void SpeedShoot(float speedShoot) { }
    
    [Header("Variables")]
    [SerializeField] private float health = 20f;
    [SerializeField] private float speedObstacle = 3f;
    private Vector2 _speedDirection;
    
    [Header("References")]
    private Rigidbody2D _rb;
    private Animator _animator;
    
    [Header("Initial Values")] 
    private float _initialSpeedObstacle;
    
    
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _initialSpeedObstacle = speedObstacle;
    }
    
    // Subscribe and Unsubscribe Events
    private void OnEnable()
    {
        GameEvents.OnObstacleSpeedMovementModified += SpeedMovement;
        GameEvents.OnObstacleResetValues += ResetValues;
    }

    private void OnDisable()
    {
        GameEvents.OnObstacleSpeedMovementModified -= SpeedMovement;
        GameEvents.OnObstacleResetValues -= ResetValues;
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
        _animator.SetTrigger("Hit");
        if (health <= 0f)
        {
            AnimateDeath();
        }
    }
    
    public void AnimateDeath()
    {
        StartCoroutine(WaitToDestroy());
    }

    IEnumerator WaitToDestroy()
    {
        speedObstacle = 0f;
        _animator.SetBool("IsDead", true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    
    // Reset Values
    public void ResetValues()
    {
        speedObstacle = _initialSpeedObstacle;
    }
}
