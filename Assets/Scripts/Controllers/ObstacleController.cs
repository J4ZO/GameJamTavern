using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private Obstacles _obstacle;
    [SerializeField] private float speedObstacle;
    private Vector2 _speedDirection;
    
    void Start()
    {
        _obstacle = GetComponent<Obstacles>();
        _speedDirection = new Vector2(-speedObstacle, 0f);
    }

 

    private void FixedUpdate()
    {
        _obstacle.MoveObstacle(_speedDirection);
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
