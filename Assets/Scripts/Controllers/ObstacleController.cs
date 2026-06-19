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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _obstacle.MoveObstacle(_speedDirection);
    }
}
