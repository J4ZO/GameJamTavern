using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Obstacles _obstacle;
    
    void Start()
    {
        _obstacle = GetComponent<Obstacles>();
        
    }

    private void Update()
    {
        _obstacle.SetSpeedDirection();
    }

    private void FixedUpdate()
    {
        _obstacle.MoveObstacle();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var entity = other.GetComponent<IDamageable>();
        if (other.CompareTag("Player") && entity != null)
        {
            entity.TakeDamage(1);
            Destroy(gameObject);
        } else if (other.CompareTag("Wall"))
        {
            Debug.Log("Touched wall");
            Destroy(gameObject);
        }
    }
}
