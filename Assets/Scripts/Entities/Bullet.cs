using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _currentSpeed; 
    private Vector2 _speedDirection;
    private String _target;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable()
    {
        ShootingSystem.Instance.AddBullet(this);
    }
    
    public String GetTarget()
    {
        return _target;
    }
    
    public void SetTarget(String target)
    {
        _target = target;
    }
    
    
    public void Move()
    {
        _rb.MovePosition(_rb.position + _currentSpeed * Time.fixedDeltaTime);
    }
    
    public void SetSpeedDirection(Vector2 speed)
    {
        _currentSpeed = speed;
    }
}
